using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Commands;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueOrFalseQuestionAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public TrueOrFalseQuestionAnswersController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateTrueOrFalseQuestionAnswerDTO createTrueOrFalseQuestionAnswerDTO)
        {
            try
            {
                createTrueOrFalseQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserId();
                await _mediator.Send(new CreateTrueOrFalseQuestionAnswerRequest() { CreateTrueOrFalseQuestionAnswerDTO = createTrueOrFalseQuestionAnswerDTO });
                return NoContent();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetTrueOrFalseQuestionAnswerByIdRequest() { Id = Id });
            if(result==null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetTrueOrFalseQuestionAnswerDTO>.Success(result, 200));
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetTrueOrFalseQuestionAnswerRequest() { PaginateRequest= paginateRequestDTO });
            if (result.Data.Count==0)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<PaginateResponse<GetTrueOrFalseQuestionAnswerDTO>>.Success(result, 200));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteTrueOrFalseQuestionAnswerRequest() { Id = Id });
            return NoContent();
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateTrueOrFalseQuestionAnswerDTO updateTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateTrueOrFalseQuestionAnswerRequest() { UpdateTrueOrFalseQuestionAnswerDTO = updateTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }
    }
}
