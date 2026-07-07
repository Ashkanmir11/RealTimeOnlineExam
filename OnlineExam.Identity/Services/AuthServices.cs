using Microsoft.AspNetCore.Identity;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Response;
using System;
using OnlineExam.Application.DTOs.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Identity.Model;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity.Validation;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Data;
using OnlineExam.Application.Constants;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace OnlineExam.Identity.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<OnlineExamUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public AuthServices(UserManager<OnlineExamUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }


        public Task<PaginateResponse<GetUserDTO>> GetAll(PaginateRequestDTO paginateRequestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Login(LoginDTO loginDto)
        {
            var validation = new LoginDtoValidaiton();
            var valid = await validation.ValidateAsync(loginDto);
            if (valid.IsValid == false)
            {
                //todo
                throw new Exception();
            }
            var role = await _roleManager.FindByNameAsync("User");
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (isPasswordValid)
            {
                JwtSecurityToken jwtSecurityToken =await GenerateToken(user);
                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            else
            {
                throw new ValidationException("نام کاربری یا رمز عبور اشتباهه است.");

            }
        }

        public async Task<GetUserDTO> Register(RegisterDTO RegisterDTO)
        {
            var validation = new RegisterDtoValidation();
            var valid = await validation.ValidateAsync(RegisterDTO, CancellationToken.None);
            var errorMassages = "";

            if (valid.IsValid == false)
            {
                foreach (var err in valid.Errors)
                {
                    errorMassages = errorMassages + err.ErrorMessage + " ";
                }
                throw new ValidationException(errorMassages);

            }

            var identityUser = new OnlineExamUser()
            {
                NationalCode = RegisterDTO.NationCode,
                Email = RegisterDTO.Email,
                EmailConfirmed = true,
                PhoneNumber = RegisterDTO.PhoneNumber,
                FirstName = RegisterDTO.FirstName,
                LastName = RegisterDTO.LastName,
                UserName = RegisterDTO.UserName,
                PhoneNumberConfirmed = true,
            };
            var result = await _userManager.CreateAsync(identityUser, RegisterDTO.Password);
            if (result.Succeeded)
            {
                var response = await _userManager.FindByEmailAsync(RegisterDTO.Email);
                var role = await _userManager.AddToRoleAsync(response, "User");
                return new GetUserDTO()
                {
                    Email = response.Email,
                    FirstName = response.FirstName,
                    LastName = response.LastName,
                    Phone = response.PhoneNumber,
                    UserName = response.UserName,
                    Id = response.Id
                };

            }
            else
            {
                foreach (var err in result.Errors)
                {
                    errorMassages = errorMassages + err.Description + " ";
                }
                throw new ValidationException(errorMassages);

            }
        }


        private async Task<JwtSecurityToken> GenerateToken(OnlineExamUser onlineExamUser)
        {
            var userRoles = await _userManager.GetRolesAsync(onlineExamUser);
            var roleClaims = new List<Claim>();

            for (int i = 0; i < userRoles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, userRoles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName,onlineExamUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,onlineExamUser.Email),
                new Claim(CustomClaimTypes.UserId,onlineExamUser.Id),
            }.Union(roleClaims).Union(roleClaims);

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
    }
}
