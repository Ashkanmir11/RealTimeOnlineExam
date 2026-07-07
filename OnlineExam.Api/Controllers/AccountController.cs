using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly CookieHelper _cookieHelper;
        public AccountController(IAuthServices authServices, CookieHelper cookieHelper)
        {
            _authServices = authServices;
            _cookieHelper = cookieHelper;
        }
        [HttpPost("auth/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            var response = await _authServices.Register(registerDTO);
            var result = ResponseHelper<GetUserDTO>.Success(response, 201);
            return StatusCode(201,result);



        }
        [HttpPost("auth/Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loginReslt = await _authServices.Login(loginDTO);
            _cookieHelper.SetAccessToken(loginReslt.AccessToken);
            _cookieHelper.SetRefreshToken(loginReslt.RefreshToken);
            return StatusCode(200,ResponseHelper<SuccessLoginResultDTO>.Success(loginReslt, 200));

        }

        [HttpGet("Account/GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {

            var response = await _authServices.GetAll(paginateRequestDTO);
            var result = ResponseHelper<PaginateResponse<GetUserDTO>>.Success(response, 200);
            return Ok(result);


        }

        [HttpPost("auth/Logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _cookieHelper.DeleteCookie(Response, "accessToken");
            return StatusCode(204,ResponseHelper<bool>.Success(true,204));
        }

    }
}
