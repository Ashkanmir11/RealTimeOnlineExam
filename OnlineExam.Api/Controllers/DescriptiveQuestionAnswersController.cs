using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptiveAnswersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authServices;
        public DescriptiveAnswersController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateDescriptiveAnswersDTO createDescriptiveAnswersDTO)
        {
            createDescriptiveAnswersDTO.StudentId = await _authServices.GetCurrentUserId();
            await _mediator.Send(new CreateDescriptiveAnswersRequest() { CreateDescriptiveAnswersDTO = createDescriptiveAnswersDTO });
            return NoContent();
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetDescriptiveAnswersByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery]PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetDescriptiveAnswersRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteDescriptiveAnswersRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateDescriptiveAnswersDTO updateDescriptiveAnswersDTO)
        {
            await _mediator.Send(new UpdateDescriptiveAnswersRequest() { UpdateDescriptiveAnswersDTO = updateDescriptiveAnswersDTO });
            return NoContent();
        }
    }
}
