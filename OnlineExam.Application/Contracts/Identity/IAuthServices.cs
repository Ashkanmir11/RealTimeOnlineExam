using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Identity
{
    public interface IAuthServices
    {
        Task<GetUserDTO> Register(RegisterDTO registerionRequest);
        Task<List<GetUserDTO>> GetAll();
        Task<bool> Login(RegisterDTO loginRequest);
    }
}
