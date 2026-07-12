using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Features.Objection.Request.Commands;
using OnlineExam.Application.Features.Objection.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionsController : ControllerBase
    {
        private IMediator _mediator;
        public ObjectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateObjectionDTO createObjectionDTO)
        {
            ////Use if need to get added data
            //var response=await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            //return Ok(ResponseHelper<GetObjectionDTO>.Success(response, 201));
            await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            return Created();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var response = await _mediator.Send(new GetObjectionRequest() { PaginateRequest = paginateRequestDTO });
            if (response.Data.Count == 0 || response.Data == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<PaginateResponse<GetObjectionDTO>>.Success(response, 200));
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {

            var response = await _mediator.Send(new GetObjectionByIdRequest() { Id = Id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetObjectionDTO>.Success(response, 200));

        }
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteOnjectionRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateObjectionDTO updateObjectionDTO)
        {
            await _mediator.Send(new UpdateObjectionRequest() { UpdateObjectionDTO = updateObjectionDTO });
            return NoContent();
        }
    }
}
