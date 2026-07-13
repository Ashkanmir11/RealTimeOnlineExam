using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
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
        [HttpGet("Get/{Id}")]
        [Authorize]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetExamByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetExamDTO>.Success(result, 200));
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
            return Ok(ResponseHelper<PaginateResponse<GetExamDTO>>.Success(pagedResult, 200));

        }

        [HttpDelete("Delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteExamRequest() { Id = Id });
            return NoContent();
        }

        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateExamDTO updateExamDTO)
        {
            await _mediator.Send(new UpdateExamRequest() { UpdateExamDTO = updateExamDTO });
            return NoContent();

        }
    }
}
