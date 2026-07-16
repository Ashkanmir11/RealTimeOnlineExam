using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Response;
namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptiveQuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DescriptiveQuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateDescriptiveQuestionDTO createDescriptiveQuestionDTO)
        {
            await _mediator.Send(new CreateDescriptiveQuestionRequest() { CreateDescriptiveQuestionDTO = createDescriptiveQuestionDTO });
            return Created();
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var result = await _mediator.Send(new GetDescriptiveQuestionByIdRequest() { Id = Id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetDescriptiveQuestionRequest() { PaginateRequest = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteDescriptiveQuestionRequest() { Id=Id });
            return NoContent();
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateDescriptiveQuestionDTO updateDescriptiveQuestionDTO)
        {
            await _mediator.Send(new UpdateDescriptiveQuestionRequest() { UpdateDescriptiveQuestionDTO = updateDescriptiveQuestionDTO });
            return NoContent();
        }
    }

}
