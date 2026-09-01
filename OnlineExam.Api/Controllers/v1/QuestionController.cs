using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Commands;
using OnlineExam.Application.Features.Question.Request.Queries;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/questions")]
    [ApiController]
    [ApiVersion("1.0")]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateQuestionDTO createQuestionDTO)
        {
            await _mediator.Send(new CreateQuestionRequest() { CreateQuestionDTO = createQuestionDTO });
            return Created();
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetQuestionByIdRequest() { Id = id });
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
            var result = await _mediator.Send(new GetQuestionRequest() { PaginateRequest = paginateRequestDTO });
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
            await _mediator.Send(new DeleteQuestionRequest() { Id = id });
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateQuestionDTO updateQuestionDTO)
        {
            await _mediator.Send(new UpdateQuestionRequest() { UpdateQuestionDTO = updateQuestionDTO, Id = id });
            return NoContent();
        }



    }
}
