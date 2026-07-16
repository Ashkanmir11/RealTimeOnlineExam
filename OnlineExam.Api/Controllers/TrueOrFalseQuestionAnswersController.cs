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
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueOrFalseAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public TrueOrFalseAnswersController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateTrueOrFalseAnswerDTO createTrueOrFalseQuestionAnswerDTO)
        {
            try
            {
                createTrueOrFalseQuestionAnswerDTO.StudentId = await _authServices.GetCurrentUserId();
                await _mediator.Send(new CreateTrueOrFalseAnswerRequest() { CreateTrueOrFalseQuestionAnswerDTO = createTrueOrFalseQuestionAnswerDTO });
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
            var result = await _mediator.Send(new GetTrueOrFalseAnswerByIdRequest() { Id = Id });
            if(result==null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetTrueOrFalseAnswerDTO>.Success(result, 200));
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetTrueOrFalseAnswerRequest() { PaginateRequest= paginateRequestDTO });
            if (result.Data.Count==0)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<PaginateResponse<GetTrueOrFalseAnswerDTO>>.Success(result, 200));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteTrueOrFalseAnswerRequest() { Id = Id });
            return NoContent();
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateTrueOrFalseAnswerDTO updateTrueOrFalseQuestionAnswerDTO)
        {
            await _mediator.Send(new UpdateTrueOrFalseAnswerRequest() { UpdateTrueOrFalseQuestionAnswerDTO = updateTrueOrFalseQuestionAnswerDTO });
            return NoContent();
        }
    }
}
