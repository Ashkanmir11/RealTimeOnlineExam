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
        Task<bool> UserExistAsync(string UserId);
        Task<List<UserNameAndLastNameDTO>> GetUsersByIds(List<string> UserId);
        Task<PaginateResponse<UserFullInfoDTO>> GetAllUsersAsync(PaginateRequestDTO paginateRequestDTO);
        Task<GetUserDTO> GetUserById(string UserId);
        Task<bool> PhoneExist(string Phone);
       
    }
}
