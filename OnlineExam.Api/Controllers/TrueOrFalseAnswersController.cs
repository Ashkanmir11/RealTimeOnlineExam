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
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries;
namespace OnlineExam.Api.Controllers
{
    [Route("api/true-or-false-answers")]
    [ApiController]
    public class TrueOrFalseAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrueOrFalseAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateTrueOrFalseAnswerDTO createTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new CreateTrueOrFalseAnswerRequest() { CreateTrueOrFalseQuestionAnswerDTO = createTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetTrueOrFalseAnswerByIdRequest() { Id = id });
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
            var result = await _mediator.Send(new GetTrueOrFalseAnswerRequest() { PaginateRequest = paginateRequestDTO });
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
            await _mediator.Send(new DeleteTrueOrFalseAnswerRequest() { Id = id });
            return NoContent();
        }
        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(int id,UpdateTrueOrFalseAnswerDTO updateTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateTrueOrFalseAnswerRequest() {Id=id, UpdateTrueOrFalseQuestionAnswerDTO = updateTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }

        [HttpPut("{id}/Grade")]
        [Authorize]
        public async Task<IActionResult> Grade(int id,UpdateTrueOrFalseAnswerTeacherDTO updateTrueOrFalseAnswerTeacherDTO)
        {
            await _mediator.Send(new UpdateTrueOrFalseAnswerTeacherRequest() {Id=id, UpdateTrueOrFalseAnswerTeacherDTO = updateTrueOrFalseAnswerTeacherDTO });
            return NoContent();
        }
        [Authorize]
        [HttpGet("my/{trueOrFalseQuestionId}")]
        public async Task<IActionResult> GetMyAnswer(int trueOrFalseQuestionId)
        {
            var result = await _mediator.Send(new GetMyTrueOrFalseAnswerRequest() { TrueOrFalseQuestionId = trueOrFalseQuestionId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
