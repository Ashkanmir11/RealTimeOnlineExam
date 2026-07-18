using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Response;
using OnlineExam.Application.Features.TrueOrFalseQuestion;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Queries;
using OnlineExam.Api.Herlpers;
using Microsoft.AspNetCore.Authorization;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrueOrFalseQuestionController : ControllerBase
    {
        //private readonly IMediator _mediator;
        //public TrueOrFalseQuestionController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        //[HttpPost("Post")]
        //[Authorize]
        //public async Task<IActionResult> Post(CreateTrueOrFalseQuestionDTO createTrueOrFalseQuestionDTO)
        //{
        //    await _mediator.Send(new CreateTrueOrFalseQuestionRequest() { CreateTrueOrFalseQuestionDTO = createTrueOrFalseQuestionDTO });
        //    return Created();
        //}

        //[HttpGet("Get/{Id}")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Get(int Id)
        //{
        //    var result = await _mediator.Send(new GetTrueOrFalseQuestionByIdRequest() { Id = Id });
        //    if (result == null)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(result);
        //}

        //[HttpGet("Get")]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        //{
        //    var result = await _mediator.Send(new GetTrueOrFalseQuestionRequest() { PaginateRequest= paginateRequestDTO });
        //    if (result.Data.Count==0)
        //    {
        //        return NoContent();
        //    }

        //    return Ok(result);
        //}
        //[HttpDelete("Delete/{Id}")]
        //[Authorize]
        //public async Task<IActionResult> Delete(int Id)
        //{
        //    await _mediator.Send(new DeleteTrueOrFalseQuestionRequest() { Id = Id });   
        //    return NoContent();
        //}

        //[HttpPut("Put")]
        //[Authorize]
        //public async Task<IActionResult> Put(UpdateTrueOfFalseQuestionDTO updateTrueOfFalseQuestionDTO)
        //{
        //    await _mediator.Send(new UpdateTrueOrFalseQuestionRequest() { UpdateTrueOfFalseQuestionDTO = updateTrueOfFalseQuestionDTO });
        //    return Created();
        //}
    }
}

