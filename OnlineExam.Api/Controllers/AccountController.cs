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

        public AccountController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost("auth/Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {

            var response = await _authServices.Register(registerDTO);
            var result = ResponseHelper<GetUserDTO>.Success(response, 201);
            return Ok(result);



        }
        [HttpPost("auth/Login")]
        public Task<IActionResult> Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Account/GetAll")]

        public async Task<IActionResult> GetAll(PaginateRequestDTO paginateRequestDTO)
        {
            try
            {
                var response = await _authServices.GetAll(paginateRequestDTO);
                var result = ResponseHelper<PaginateResponse<GetUserDTO>>.Success(response, 200);
                return Ok(result);
            }
            catch
            {
                throw;
            }

        }
    }
}
