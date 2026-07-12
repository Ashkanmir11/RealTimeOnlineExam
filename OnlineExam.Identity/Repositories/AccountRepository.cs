using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OnlineExamIdentityDbContext _context;
        private readonly UserManager<OnlineExamUser> _userManager;
        public AccountRepository(OnlineExamIdentityDbContext context, UserManager<OnlineExamUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<List<UserDTO>> GetUsersByIds(List<string> UserId)
        {
            var result = new List<UserDTO>();
            var users = await _context.Users.Where(e => UserId.Contains(e.Id)).ToListAsync();
            foreach (var user in users)
            {
                result.Add(new UserDTO()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                });
            }
            return result;
        }

        public async Task<bool> UserExistAsync(string UserId)
        {
            return await _context.Users.AnyAsync(e => e.Id == UserId);
        }
    }
}
