using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineExam.Application.Constants;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Services
{
    public class TokenServices
    {
        private readonly UserManager<OnlineExamUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly OnlineExamIdentityDbContext _context;
        public TokenServices(UserManager<OnlineExamUser> userManager, IOptions<JwtSettings> jwtSettings, OnlineExamIdentityDbContext context)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _context = context;
        }

        public async Task<JwtSecurityToken> GenerateAccessTokenAsync(OnlineExamUser onlineExamUser)
        {
            var userRoles = await _userManager.GetRolesAsync(onlineExamUser);
            var roleClaims = new List<Claim>();

            for (int i = 0; i < userRoles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, userRoles[i]));
            }
            var claims = new[]
            {
                new Claim(CustomClaimTypes.PhoneNumber,onlineExamUser.PhoneNumber),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,onlineExamUser.Email),
                new Claim(CustomClaimTypes.UserId,onlineExamUser.Id),
            }.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
        public async Task<RefreshToken> AddRefreshTokenAsync(string userId)
        {
            var newRefreshToken = new RefreshToken()
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Token = GenerateRefreshToken(),
                ExpireDate = DateTime.UtcNow.AddDays(10)
            };
            await _context.RefreshTokens.AddAsync(newRefreshToken);
            await _context.SaveChangesAsync();
            return newRefreshToken;
        }
        private string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

        public async Task<GetTokens> RefreshTokenAsync(string refreshToken)
        {
            var expiredRefeshTokens = await _context.RefreshTokens.Where(e => e.ExpireDate < DateTime.UtcNow).ToListAsync();
            if (expiredRefeshTokens.Count > 0)
            {
                _context.RemoveRange(expiredRefeshTokens);
                await _context.SaveChangesAsync();
            }
            var rToken = await _context.RefreshTokens.Where(e => e.Token == refreshToken).FirstOrDefaultAsync();
            if (rToken == null)
            {
                throw new UnauthorizedAccessException("لطفا ابتدا وارد شوید.");

            }
            var user = await _userManager.FindByIdAsync(rToken.UserId);
            var securityToken = await GenerateAccessTokenAsync(user);
            new JwtSecurityTokenHandler().WriteToken(securityToken);
            _context.RefreshTokens.Remove(rToken);
            await _context.SaveChangesAsync();
            var newRefreshToken = await AddRefreshTokenAsync(user.Id);

            var result = new GetTokens()
            {
                RefreshToken = newRefreshToken.Token,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(securityToken)
            };
            return result;


        }

        public async Task DeleteRefreshToken(string refreshToken)
        {
            var token = _context.RefreshTokens.Where(e => e.Token == refreshToken).FirstOrDefault();
            if (token == null)
            {
                throw new UnauthorizedAccessException();
            }
            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync();
        }

    }
}
