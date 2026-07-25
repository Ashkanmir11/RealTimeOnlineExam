using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.AIServices;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Commands;
using OnlineExam.Application.Features.Exam.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateExamDTO createExamDTO)
        {
            await _mediator.Send(new CreateExamRequest() { CreateExamDTO = createExamDTO });
            return Created();
        }
        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetExamByIdRequest() { Id = id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var pagedResult = await _mediator.Send(new GetExamRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (pagedResult.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(pagedResult);

        }

        [HttpDelete("Delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteExamRequest() { Id = id });
            return NoContent();
        }

        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateExamDTO updateExamDTO)
        {
            await _mediator.Send(new UpdateExamRequest() { UpdateExamDTO = updateExamDTO });
            return NoContent();

        }
        [HttpPost("Start/{examId}")]
        [Authorize]
        public async Task<IActionResult> Start([FromQuery] PaginateRequestDTO paginateRequestDTO, int examId)
        {
            var result = await _mediator.Send(new StartExamRequest() { ExamId = examId, paginateRequestDTO = paginateRequestDTO });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPost("End/{examId}")]
        [Authorize]
        public async Task<IActionResult> End(int examId)
        {
            await _mediator.Send(new EndExamRequest() { ExamId = examId });
            return NoContent();
        }
        [HttpPost("Summery/{examId}")]
        [Authorize]
        public async Task<IActionResult> ExamSummery(int examId)
        {
            var result = await _mediator.Send(new GetExamSummeryRequest() { ExamId = examId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Class/{classId}")]
        [Authorize]
        public async Task<IActionResult> GetByClassId(int classId, [FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetExamByClassIdRequest() { ClassId = classId, PaginateRequestDTO = paginateRequestDTO });
            if(result.Data.Count==0)
            {
                return NoContent();
            }
            return Ok(result);
        }

    }
}
