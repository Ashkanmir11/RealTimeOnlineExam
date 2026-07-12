using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Objection;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionsController : ControllerBase
    {
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateObjectionDTO createObjectionDTO)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            throw new NotImplementedException();


        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            throw new NotImplementedException();

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put()
        {
            throw new NotImplementedException();

        }
    }
}
