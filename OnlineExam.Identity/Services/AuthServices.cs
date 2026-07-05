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


namespace OnlineExam.Identity.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Task<List<GetUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Login(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public Task<GetUserDTO> Register(RegisterDTO RegisterDTO)
        {
            throw new BadRequestException("Input Not Valid");
        }
    }
}
