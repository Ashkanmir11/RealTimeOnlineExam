using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Commands;
using OnlineExam.Application.Features.ExamLog.Request.Queries;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamLogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateExamLogDTO createExamLogDTO)
        {
            await _mediator.Send(new CreateExamLogRequest() { CreateExamLogDTO = createExamLogDTO });
            return NoContent();
        }
        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetExamLogByIdRequest() { Id = id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(PaginateRequestDTO paginateRequestDTO)
        {
            var result=await _mediator.Send(new GetExamLogRequest() { PaginateRequestDTO = paginateRequestDTO });
            if(result.Data.Count==0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("GetByStudentId/{StudentId}")]
        [Authorize]
        public async Task<IActionResult> GetByStudentId(string StudentId)
        {
            throw new NotImplementedException();
        }
    }
}
