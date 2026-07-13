using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

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
        public async Task<PaginateResponse<UserFullInfoDTO>> GetAllUsersAsync(PaginateRequestDTO paginateRequestDTO)
        {
            var userData = new List<UserFullInfoDTO>();
            var skip = PaginateHelper<UserFullInfoDTO>.GetSkip(paginateRequestDTO);
            var totalCount = await _context.Users.CountAsync();
            IQueryable<OnlineExamUser> query = _context.Users;
            if (paginateRequestDTO.SortBy != null)
            {
                query = QuerySortHelper<OnlineExamUser>.Sort(query, paginateRequestDTO);
            }


            var users = await query.Skip(skip).Take(paginateRequestDTO.PageCount).ToListAsync();

            foreach (var user in users)
            {
                var roleIds = await _context.UserRoles.Where(e => e.UserId == user.Id).Select(e => e.RoleId).ToListAsync();
                var roleNames = await _context.Roles.Where(e => roleIds.Contains(e.Id)).Select(e => e.Name).ToListAsync();

                userData.Add(new UserFullInfoDTO()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.UserName,
                    Roles = roleNames
                });
            }
            return PaginateHelper<UserFullInfoDTO>.Paginate(userData, totalCount, paginateRequestDTO.PageCount, paginateRequestDTO.PageNumber);

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
