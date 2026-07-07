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
        private readonly TokenServices _tokenServices;
        public AuthServices(UserManager<OnlineExamUser> userManager, RoleManager<IdentityRole> roleManager, TokenServices tokenServices)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenServices = tokenServices;
        }


        public Task<PaginateResponse<GetUserDTO>> GetAll(PaginateRequestDTO paginateRequestDTO)
        {
            throw new NotImplementedException();
        }

      

        public async Task<SuccessLoginResultDTO> Login(LoginDTO loginDto)
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



    }
}
