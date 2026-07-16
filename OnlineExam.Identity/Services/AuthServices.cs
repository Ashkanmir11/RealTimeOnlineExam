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
using OnlineExam.Application.Helper;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace OnlineExam.Identity.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<OnlineExamUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenServices _tokenServices;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IValidator<LoginDTO> _validator;
        private readonly OnlineExamIdentityDbContext _context;
        public AuthServices(UserManager<OnlineExamUser> userManager, RoleManager<IdentityRole> roleManager, TokenServices tokenServices
            , IHttpContextAccessor httpContextAccessor,IValidator<LoginDTO> validator, OnlineExamIdentityDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenServices = tokenServices;
            _httpContextAccessor = httpContextAccessor;
            _validator = validator;
            _context = context;
        }


        public Task<PaginateResponse<GetUserDTO>> GetAllAsync(PaginateRequestDTO paginateRequestDTO)
        {
            throw new NotImplementedException();
        }
        public async Task<SuccessLoginResultDTO> LoginAsync(LoginDTO loginDto)
        {
            var validationResult = await _validator.ValidateAsync(loginDto);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e=>e.ErrorMessage).ToList());
            }
            //var role = await _roleManager.FindByNameAsync("User");
            var user = await _context.Users.Where(e=>e.PhoneNumber==loginDto.PhoneNumber).FirstOrDefaultAsync();
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (isPasswordValid)
            {

                JwtSecurityToken jwtSecurityToken = await _tokenServices.GenerateAccessTokenAsync(user);
                var refreshToken = await _tokenServices.AddRefreshTokenAsync(user.Id);
                var result = new SuccessLoginResultDTO()
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    RefreshToken = refreshToken.Token,
                    User = new GetUserDTO()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Phone = user.PhoneNumber,
                        UserName = user.UserName,
                        Id = user.Id
                    },
                };
                return result;

            }
            else
            {

                throw new UnauthorizedAccessException("نام کاربری یا رمز عبور اشتباهه است.");

            }
        }

        public async Task<GetUserDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            var validation = new RegisterDtoValidation();
            var valid = await validation.ValidateAsync(registerDTO, CancellationToken.None);

            if (valid.IsValid == false)
            {
                var errors = valid.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);

            }

            var identityUser = new OnlineExamUser()
            {
                NationalCode = registerDTO.NationCode,
                Email = registerDTO.Email,
                EmailConfirmed = true,
                PhoneNumber = registerDTO.PhoneNumber,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                UserName = registerDTO.UserName,
                PhoneNumberConfirmed = true,
            };
            var result = await _userManager.CreateAsync(identityUser, registerDTO.Password);
            if (result.Succeeded)
            {
                var response = await _userManager.FindByEmailAsync(registerDTO.Email);
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
                throw new Application.Exceptions.ValidationException(result.Errors.Select(e=>e.Description).ToList());
            }
        }
        public async Task<GetTokens> RefreshTokenAsync(string refreshToken)
        {
            return await _tokenServices.RefreshTokenAsync(refreshToken);
        }

        public async Task<string> GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == CustomClaimTypes.UserId)?.Value;

        }
    }
}
