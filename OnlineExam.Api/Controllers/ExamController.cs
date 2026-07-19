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
        private readonly IAiServices _aiServices;
        public ExamController(IMediator mediator, IAiServices aiServices)
        {
            _mediator = mediator;
            _aiServices = aiServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateExamDTO createExamDTO)
        {
            await _mediator.Send(new CreateExamRequest() { CreateExamDTO = createExamDTO });
            return Created();
        }
        [HttpGet("Get/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetExamByIdRequest() { Id = Id });
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
        [HttpPost("Start/{ExamId}")]
        [Authorize]
        public async Task<IActionResult> Start([FromQuery] PaginateRequestDTO paginateRequestDTO, int ExamId)
        {
            var result = await _mediator.Send(new StartExamRequest() { ExamId = ExamId, paginateRequestDTO = paginateRequestDTO });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPost("End/{ExamId}")]
        public async Task<IActionResult> End(int ExamId)
        {
            // await _mediator.Send(new EndExamRequest() { ExamId = ExamId });
            var aiServices = _aiServices.GetScore("موتور هواپیما سوخت مخصوص دارد.", "هواپیما سوخت مخصوص دارد.", 2);
            return NoContent();
        }
    }
}
