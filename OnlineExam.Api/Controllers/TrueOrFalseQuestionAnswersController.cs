using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueOrFalseQuestionAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrueOrFalseQuestionAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post()
        {
            throw new NotImplementedException();
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("Post")]
        public async Task<IActionResult> Put()
        {
            throw new NotImplementedException();
        }
    }
}
