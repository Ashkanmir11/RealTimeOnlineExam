using OnlineExam.Application.DTOs.Common;
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
        Task<PaginateResponse<GetUserDTO>> GetAll(PaginateRequestDTO paginateRequestDTO);
        Task<string> Login(LoginDTO loginRequest);
    }
}
