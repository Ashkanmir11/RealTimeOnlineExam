using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Commands;
using OnlineExam.Application.Features.Exam.Request.Queries;
using OnlineExam.Application.Features.Question.Request.Queries;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/exams")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ExamController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public ExamController(IMediator mediator, IAuthServices authServices)
        {
            _authServices = authServices;
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateExamDTO createExamDTO)
        {
            await _mediator.Send(new CreateExamRequest() { CreateExamDTO = createExamDTO });
            return Created();
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetExamByIdRequest() { Id = id });
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
            var pagedResult = await _mediator.Send(new GetExamRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (pagedResult.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(pagedResult);

        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteExamRequest() { Id = id });
            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateExamDTO updateExamDTO)
        {
            await _mediator.Send(new UpdateExamRequest() { UpdateExamDTO = updateExamDTO, Id = id });
            return NoContent();

        }
        [HttpPost("{examId}/start")]
        [Authorize]
        public async Task<IActionResult> Start([FromQuery] PaginateRequestDTO paginateRequestDTO, int examId)
        {
            var result = await _mediator.Send(new StartExamRequest() { ExamId = examId, paginateRequestDTO = paginateRequestDTO });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpPost("{examId}/end")]
        [Authorize]
        public async Task<IActionResult> End(int examId)
        {
            await _mediator.Send(new EndExamRequest() { ExamId = examId });
            return NoContent();
        }
        [HttpGet("{examId}/summary")]
        [Authorize]
        public async Task<IActionResult> ExamSummery(int examId)
        {
            var result = await _mediator.Send(new GetExamSummeryRequest() { ExamId = examId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("class-room/{classId}")]
        [Authorize]
        public async Task<IActionResult> GetByClassId(int classId, [FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetExamByClassIdRequest() { ClassId = classId, PaginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("{examId}/answers/{studentId}")]
        [Authorize]
        public async Task<IActionResult> GetStudentScore(int examId, string studentId, [FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetQuestionWithAnswerRequest() { ExamId = examId, StudentId = studentId, PaginateRequestDTO = paginateRequestDTO });
            return Ok(result);
        }
        [HttpGet("{examId}/questions")]
        [Authorize]
        public async Task<IActionResult> GetQuestions(int examId, [FromQuery] PaginateRequestDTO paginateRequestDTO)
        {

            var result = await _mediator.Send(new GetQuestionTeacherRequest() { ExamId = examId, PaginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        //[HttpGet("test")]
        //[Authorize]
        //public async Task<IActionResult> test(int examId)
        //{

        //    var remainingSeconds = await _mediator.Send(new GetExamRemainSecondsRequest() { ExamId = examId });
        //    return Ok(Convert.ToInt32(remainingSeconds));
        //}

    }
}
