using OnlineExam.Application.DTOs.Identity;
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
        Task<List<UserDTO>> GetUsersByIds(List<string> UserId);
    }
}
