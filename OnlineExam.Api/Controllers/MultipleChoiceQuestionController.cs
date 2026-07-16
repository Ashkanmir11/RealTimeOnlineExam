using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceQuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MultipleChoiceQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateMultipleChoiceQuestionDTO createMultipleChoiceQuestionDTO)
        {
            await _mediator.Send(new CreateMultipleChoiceQuestionRequest() { CreateMultipleChoiceQuestionDTO = createMultipleChoiceQuestionDTO });
            return NoContent();
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetMultipleChoiceQuestionByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetMultipleChoiceQuestionRequest() { paginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteMultipleChoiceQuestionRequest() { Id = Id });
            return NoContent();
        }
        [HttpPut("Put")]

        public async Task<IActionResult> Put(UpdateMultipleChoiceQuestionDTO updateMultipleChoiceQuestionDTO)
        {
            await _mediator.Send(new UpdateMultipleChoiceQuestionRequest() { UpdateMultipleChoiceQuestionDTO = updateMultipleChoiceQuestionDTO });
            return NoContent();
        }
    }
}
