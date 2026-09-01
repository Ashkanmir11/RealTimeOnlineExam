using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Application.Features.ExamLog.Request.Commands;
using OnlineExam.Application.Features.ExamLog.Request.Queries;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/exam-logs")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExamLogController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamLogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateExamLogDTO createExamLogDTO)
        {
            await _mediator.Send(new CreateExamLogRequest() { CreateExamLogDTO = createExamLogDTO });
            return NoContent();
        }
        [HttpGet("{id}")]
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
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetExamLogRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{examId}/{studentId}")]
        [Authorize]
        public async Task<IActionResult> GetByStudentId(int examId, string studentId)
        {
            var result = await _mediator.Send(new GetExamLogForTeacherRequest() { ExamId = examId, StudentId = studentId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
