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

namespace OnlineExam.Identity.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<OnlineExamUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthServices(UserManager<OnlineExamUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public Task<PaginateResponse<GetUserDTO>> GetAll(PaginateRequestDTO paginateRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
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
                    errorMassages = errorMassages + err.ErrorMessage + ".";
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
                    errorMassages = errorMassages + err.Description + "-";
                }
                throw new ValidationException(errorMassages);

            }
        }
    }
}
