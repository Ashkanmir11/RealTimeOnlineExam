using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptiveQuestionAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public DescriptiveQuestionAnswersController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateDescriptiveQuestionAnswersDTO createDescriptiveQuestionAnswersDTO)
        {
            createDescriptiveQuestionAnswersDTO.StudentId = await _authServices.GetCurrentUserId();
            await _mediator.Send(new CreateDescriptiveQuestionAnswersRequest() { CreateDescriptiveQuestionAnswersDTO = createDescriptiveQuestionAnswersDTO });
            return NoContent();
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetDescriptiveQuestionAnswersByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetDescriptiveQuestionAnswersDTO>.Success(result, 200));
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery]PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetDescriptiveQuestionAnswersRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<PaginateResponse<GetDescriptiveQuestionAnswersDTO>>.Success(result, 200));
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteDescriptiveQuestionAnswersRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateDescriptiveQuestionAnswersDTO updateDescriptiveQuestionAnswersDTO)
        {
            await _mediator.Send(new UpdateDescriptiveQuestionAnswersRequest() { UpdateDescriptiveQuestionAnswersDTO = updateDescriptiveQuestionAnswersDTO });
            return NoContent();
        }
    }
}
