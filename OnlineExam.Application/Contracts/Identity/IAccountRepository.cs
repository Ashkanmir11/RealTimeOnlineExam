using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Response;

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
        Task<GetMyUserInfoDTO> GetMyInfoAsync(string userId);

    }
}
