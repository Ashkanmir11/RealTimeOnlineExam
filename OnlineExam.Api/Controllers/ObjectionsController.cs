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

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAuthServices _authservices;
        public ObjectionsController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authservices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateObjectionDTO createObjectionDTO)
        {
            var studentId = await _authservices.GetCurrentUserId();
            createObjectionDTO.StudentId = studentId;


            ////Use if need to get added data
            //var response=await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            //return Ok(ResponseHelper<GetObjectionDTO>.Success(response, 201));


            await _mediator.Send(new CreateObjectionReqeust() { CreateObjectionDTO = createObjectionDTO });
            return Created();
        }
        [HttpGet("Get")]
        [Authorize]
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
        [Authorize]
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
