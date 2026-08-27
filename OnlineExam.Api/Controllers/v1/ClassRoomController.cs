using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/class-rooms")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClassRoomController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateClassRoomDTO createClassRoomDTO)
        {
            var result = await _mediator.Send(new CreateClassRoomRequest() { CreateClassRoomDTO = createClassRoomDTO });
            return Created();
        }
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetClassRoomByIdRequest() { Id = id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
        [HttpGet]
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

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteClassRoomRequest() { Id = id });
            return NoContent();
        }


        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateClassRoomDTO updateClassRoomDto, int id)
        {
            await _mediator.Send(new UpdateClassRoomRequest() { Id = id, UpdateClassRoomDTO = updateClassRoomDto });
            return Ok();
        }
        [HttpGet("my/as-teacher")]
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
        [HttpGet("my/as-student")]
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
