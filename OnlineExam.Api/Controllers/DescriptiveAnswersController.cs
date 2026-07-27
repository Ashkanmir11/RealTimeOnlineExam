using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Handler.Queries;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/descriptive-answers")]
    [ApiController]
    public class DescriptiveAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DescriptiveAnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateDescriptiveAnswersDTO createDescriptiveAnswersDTO)
        {
            await _mediator.Send(new CreateDescriptiveAnswersRequest() { CreateDescriptiveAnswersDTO = createDescriptiveAnswersDTO });
            return NoContent();
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetDescriptiveAnswersByIdRequest() { Id = id });
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
            var result = await _mediator.Send(new GetDescriptiveAnswersRequest() { PaginateRequest = paginateRequestDTO });
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
            await _mediator.Send(new DeleteDescriptiveAnswersRequest() { Id = id });
            return NoContent();

        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id,UpdateDescriptiveAnswersDTO updateDescriptiveAnswersDTO)
        {
            await _mediator.Send(new UpdateDescriptiveAnswersRequest() {Id=id, UpdateDescriptiveAnswersDTO = updateDescriptiveAnswersDTO });
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}/grade")]
        public async Task<IActionResult> Grading(int id,UpdateDescriptiveAnswersTeacherDTO updateDescriptiveAnswersTeacherDTO)
        {
            await _mediator.Send(new UpdateDescriptiveAnswersTeacherRequest() { updateDescriptiveAnswersTeacherDTO = updateDescriptiveAnswersTeacherDTO });
            return NoContent();
        }
        [Authorize]
        [HttpGet("my/{descriptiveQuestionId}")]
        public async Task<IActionResult> GetMyAnswer(int descriptiveQuestionId)
        {
            var result = await _mediator.Send(new GetMyDescriptiveAnswerRequest() { descriptiveQuestionId = descriptiveQuestionId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
