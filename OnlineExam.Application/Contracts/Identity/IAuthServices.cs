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
        Task<GetUserDTO> RegisterAsync(RegisterDTO registerionRequest);
        Task<PaginateResponse<GetUserDTO>> GetAllAsync(PaginateRequestDTO paginateRequestDTO);
        Task<SuccessLoginResultDTO> LoginAsync(LoginDTO loginRequest);
        Task<GetTokens> RefreshTokenAsync(string refreshToken);

        Task<string> GetCurrentUserId();

    }
}
