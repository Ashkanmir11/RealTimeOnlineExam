using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Commands;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueOrFalseAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrueOrFalseAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateTrueOrFalseAnswerDTO createTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new CreateTrueOrFalseAnswerRequest() { CreateTrueOrFalseQuestionAnswerDTO = createTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }
        [HttpGet("Get/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetTrueOrFalseAnswerByIdRequest() { Id = Id });
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
            var result = await _mediator.Send(new GetTrueOrFalseAnswerRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteTrueOrFalseAnswerRequest() { Id = Id });
            return NoContent();
        }
        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateTrueOrFalseAnswerDTO updateTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateTrueOrFalseAnswerRequest() { UpdateTrueOrFalseQuestionAnswerDTO = updateTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }
    }
}
