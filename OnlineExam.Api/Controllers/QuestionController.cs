using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Commands;
using OnlineExam.Application.Features.Question.Request.Queries;

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
        [Authorize(Roles = "Admin")]
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetQuestionByIdRequest() { Id = id });
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
            var result = await _mediator.Send(new GetQuestionRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteQuestionRequest() { Id = id });
            return NoContent();
        }
        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateQuestionDTO updateQuestionDTO)
        {
            await _mediator.Send(new UpdateQuestionRequest() { UpdateQuestionDTO = updateQuestionDTO });
            return NoContent();
        }

        //[HttpGet("GetWithAnswers")]
        //public async Task<IActionResult> GetStudentScore([FromQuery] int examId, [FromQuery] string studentId, [FromQuery] PaginateRequestDTO paginateRequestDTO)
        //{
        //    var result = await _mediator.Send(new GetQuestionWithAnswerRequest() { ExamId = examId, StudentId = studentId, PaginateRequestDTO = paginateRequestDTO });
        //    return Ok(result);
        //}

    }
}
