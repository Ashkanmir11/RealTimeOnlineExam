using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Commands;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;
using OnlineExam.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MultipleChoiceAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateMultipleChoiceAnswerDTO createMultipleChoiceQuestionAnswerDTO)
        {
            await _mediator.Send(new CreateMultipleChoiceAnswerRequest() { CreateMultipleChoiceQuestionAnswerDTO = createMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
        [HttpGet("Get/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetMultipleChoiceAnswerByIdRequest() { Id = Id });
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
            var result = await _mediator.Send(new GetMultipleChoiceAnswerRequest() { PaginateRequest = paginateRequestDTO });
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
            await _mediator.Send(new DeleteMultipleChoiceAnswerRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateMultipleChoiceAnswerDTO updateMultipleChoiceQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateMultipleChoiceAnswerRequest() { UpdateMultipleChoiceQuestionAnswerDTO = updateMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
    }
}
