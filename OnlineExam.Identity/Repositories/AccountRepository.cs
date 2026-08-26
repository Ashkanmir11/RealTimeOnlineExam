using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
using OnlineExam.Identity.Model;
using System.Linq.Dynamic.Core;

namespace OnlineExam.Identity.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly OnlineExamIdentityDbContext _context;
        private readonly UserManager<OnlineExamUser> _userManager;
        private readonly IMapper _mapper;
        public AccountRepository(OnlineExamIdentityDbContext context, UserManager<OnlineExamUser> userManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
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
            return PaginateHelper<UserFullInfoDTO>.Paginate(userData, totalCount, paginateRequestDTO);

        }

        public async Task<GetMyUserInfoDTO> GetMyInfoAsync(string userId)
        {
            return await _context.Users.Where(e => e.Id == userId).ProjectTo<GetMyUserInfoDTO>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<GetUserDTO> GetUserByIdAsync(string userId)
        {
            return await _context.Users.Where(e => e.Id == userId).ProjectTo<GetUserDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<string> GetUserIdByPhoneAsync(string phone)
        {
            return await _context.Users.Where(e => e.PhoneNumber == phone).Select(e => e.Id).SingleOrDefaultAsync();
        }

        public async Task<List<UserNameAndLastNameDTO>> GetUsersByIdsAsync(List<string> userId)
        {
            return await _context.Users.Where(e => userId.Contains(e.Id)).ProjectTo<UserNameAndLastNameDTO>(_mapper.ConfigurationProvider).ToListAsync();

        }

        public async Task<List<string>> GetUsersIdByPhonesAsync(List<string> phone)
        {
            var result = await _context.Users.Where(e => phone.Contains(e.PhoneNumber)).Select(e => e.Id).ToListAsync();
            return result;
        }

        public async Task<bool> PhoneExistAsync(string phone)
        {
            return await _context.Users.AnyAsync(e => e.PhoneNumber == phone);
        }

        public async Task<bool> UserExistAsync(string userId)
        {
            return await _context.Users.AnyAsync(e => e.Id == userId);
        }
    }
}
