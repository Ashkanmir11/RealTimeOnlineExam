using Microsoft.EntityFrameworkCore;
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
    public interface IAccountRepository
    {
        Task<bool> UserExistAsync(string userId);
        Task<List<UserNameAndLastNameDTO>> GetUsersByIdsAsync(List<string> userId);
        Task<PaginateResponse<UserFullInfoDTO>> GetAllUsersAsync(PaginateRequestDTO paginateRequestDTO);
        Task<GetUserDTO> GetUserByIdAsync(string userId);
        Task<bool> PhoneExistAsync(string phone);
        Task<string> GetUserIdByPhoneAsync(string phone);
        Task<List<string>> GetUsersIdByPhonesAsync(List<string> phone);
       
    }
}
