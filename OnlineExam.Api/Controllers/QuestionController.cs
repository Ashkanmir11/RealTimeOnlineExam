using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Commands;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateQuestionDTO createQuestionDTO)
        {
            await _mediator.Send(new CreateQuestionRequest() { CreateQuestionDTO = createQuestionDTO });
            return Created();
        }
    }
}
