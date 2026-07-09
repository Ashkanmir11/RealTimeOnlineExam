using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Identity;
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

        public async Task<bool> UserExistAsync(string UserId)
        {
            return await _context.Users.AnyAsync(e => e.Id == UserId);
        }
    }
}
