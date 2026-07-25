using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Identity.Model;
using System.Security.Claims;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateClassRoomDTO createClassRoomDTO)
        {
            var result = await _mediator.Send(new CreateClassRoomRequest() { CreateClassRoomDTO = createClassRoomDTO });
            return Created();
        }
        [HttpGet("Get/{Id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _mediator.Send(new GetClassRoomByIdRequest() { Id = Id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var response = await _mediator.Send(new GetClassRoomRequest() { PaginateRequest = paginateRequestDTO });
            if (response.Data.Count == 0 || response.Data == null)
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpDelete("Delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            await _mediator.Send(new DeleteClassRoomRequest() { Id = Id });
            return NoContent();
        }


        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateClassRoomDTO updateClassRoomDto)
        {
            await _mediator.Send(new UpdateClassRoomRequest() { UpdateClassRoomDTO = updateClassRoomDto });
            return Ok();
        }
        [HttpGet("Teacher/Me")]
        [Authorize]
        public async Task<IActionResult> GetTeacherClass([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetClassRoomTeacherRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpGet("Student/Me")]
        [Authorize]
        public async Task<IActionResult> GetStudentClass([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetClassRoomStudentRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (result == null || result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }


    }
}
