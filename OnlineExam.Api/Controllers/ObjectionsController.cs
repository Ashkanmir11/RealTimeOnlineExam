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
    [Route("api/objections")]
    [ApiController]
    public class ObjectionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ObjectionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateObjectionDTO createObjectionDTO)
        { 
          
            await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            return Created();
        }
        [HttpGet]
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
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {

            var response = await _mediator.Send(new GetObjectionByIdRequest() { Id = id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);

        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteOnjectionRequest() { Id = id });
            return NoContent();

        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id,UpdateObjectionDTO updateObjectionDTO)
        {
            await _mediator.Send(new UpdateObjectionRequest() { UpdateObjectionDTO = updateObjectionDTO , Id = id });
            return NoContent();
        }
    }
}
