using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Features.Objection.Request.Commands;
using OnlineExam.Application.Features.Objection.Request.Queries;
using OnlineExam.Application.Response;
using OnlineExam.Identity.Services;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ObjectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateObjectionDTO createObjectionDTO)
        { 
          
            await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            return Created();
        }
        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var response = await _mediator.Send(new GetObjectionRequest() { PaginateRequest = paginateRequestDTO });
            if (response.Data.Count == 0 || response.Data == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet("Get/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int Id)
        {

            var response = await _mediator.Send(new GetObjectionByIdRequest() { Id = Id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);

        }
        [HttpDelete("Delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteOnjectionRequest() { Id = Id });
            return NoContent();

        }
        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateObjectionDTO updateObjectionDTO)
        {
            await _mediator.Send(new UpdateObjectionRequest() { UpdateObjectionDTO = updateObjectionDTO });
            return NoContent();
        }
    }
}
