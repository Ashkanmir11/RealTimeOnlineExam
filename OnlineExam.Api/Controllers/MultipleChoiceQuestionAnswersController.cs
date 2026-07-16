using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Commands;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;
using OnlineExam.Application.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultipleChoiceQuestionAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public MultipleChoiceQuestionAnswersController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateMultipleChoiceQuestionAnswerDTO createMultipleChoiceQuestionAnswerDTO)
        {
            createMultipleChoiceQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserId();
            await _mediator.Send(new CreateMultipleChoiceQuestionAnswerRequest() { CreateMultipleChoiceQuestionAnswerDTO = createMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetMultipleChoiceQuestionAnswerByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetMultipleChoiceQuestionAnswerDTO>.Success(result, 200));
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetMultipleChoiceQuestionAnswerRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<PaginateResponse<GetMultipleChoiceQuestionAnswerDTO>>.Success(result, 200));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteMultipleChoiceQuestionAnswerRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateMultipleChoiceQuestionAnswerDTO updateMultipleChoiceQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateMultipleChoiceQuestionAnswerRequest() { UpdateMultipleChoiceQuestionAnswerDTO = updateMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
    }
}
