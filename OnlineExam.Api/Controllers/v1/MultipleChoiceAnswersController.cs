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
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using Asp.Versioning;
namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/multiple-choice-answers")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MultipleChoiceAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MultipleChoiceAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateMultipleChoiceAnswerDTO createMultipleChoiceQuestionAnswerDTO)
        {
            await _mediator.Send(new CreateMultipleChoiceAnswerRequest() { CreateMultipleChoiceQuestionAnswerDTO = createMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetMultipleChoiceAnswerByIdRequest() { Id = id });
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
            var result = await _mediator.Send(new GetMultipleChoiceAnswerRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteMultipleChoiceAnswerRequest() { Id = id });
            return NoContent();

        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateMultipleChoiceAnswerDTO updateMultipleChoiceQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateMultipleChoiceAnswerRequest() { Id = id, UpdateMultipleChoiceQuestionAnswerDTO = updateMultipleChoiceQuestionAnswerDTO });
            return NoContent();
        }
        [HttpPut("{id}/grade")]
        [Authorize]
        public async Task<IActionResult> Grade(int id, UpdateMultipleChoiceAnswerTeacherDTO updateMultipleChoiceAnswerTeacherDTO)
        {
            await _mediator.Send(new UpdateMultipleChoiceAnswerTeacherRequest() { Id = id, UpdateMultipleChoiceAnswerTeacherDTO = updateMultipleChoiceAnswerTeacherDTO });
            return NoContent();
        }
        [Authorize]
        [HttpGet("my/{multiChoiceQuestionId}")]
        public async Task<IActionResult> GetMyAnswer(int multiChoiceQuestionId)
        {
            var result = await _mediator.Send(new GetMyMultipleChoiceAnswerRequest() { MultipleChoiceQuestionId = multiChoiceQuestionId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
