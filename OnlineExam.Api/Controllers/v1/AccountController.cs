using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly CookieHelper _cookieHelper;
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAuthServices authServices, CookieHelper cookieHelper, IAccountRepository accountRepository)
        {
            _authServices = authServices;
            _cookieHelper = cookieHelper;
            _accountRepository = accountRepository;
        }
        [HttpPost("auth/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            await _authServices.RegisterAsync(registerDTO);
            return Created();
        }
        [HttpPost("auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            if (currentUser != null)
            {
                throw new ConflictException("شما قبلا وارد شده اید.");
            }
            var loginReslt = await _authServices.LoginAsync(loginDTO);
            _cookieHelper.SetAccessToken(loginReslt.AccessToken);
            _cookieHelper.SetRefreshToken(loginReslt.RefreshToken);
            return Ok(loginReslt);

        }

        [HttpPost("auth/refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = _cookieHelper.GetCookieValue("refreshToken");
            var response = await _authServices.RefreshTokenAsync(refreshToken);
            _cookieHelper.SetAccessToken(response.AccessToken);
            _cookieHelper.SetRefreshToken(response.RefreshToken);
            return NoContent();
        }
        [HttpGet("accounts")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {

            var response = await _accountRepository.GetAllUsersAsync(paginateRequestDTO);
            if (response.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(response);

        }

        [HttpPost("auth/logout")]
        public async Task<IActionResult> Logout()
        {
            var refreshToken = _cookieHelper.GetCookieValue("refreshToken");
            await _authServices.LogoutAsync(refreshToken);
            _cookieHelper.DeleteCookie(Response, "accessToken");
            _cookieHelper.DeleteCookie(Response, "refreshToken");
            return NoContent();
        }
        [HttpGet("accounts/me")]
        [Authorize]
        public async Task<IActionResult> GetMyInfo()
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            return Ok(await _accountRepository.GetMyInfoAsync(currentUser));
        }


    }
}
