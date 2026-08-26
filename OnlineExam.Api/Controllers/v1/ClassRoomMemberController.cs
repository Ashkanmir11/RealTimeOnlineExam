using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Features.ClassRoomMember.Request.Commands;
using OnlineExam.Application.Features.ClassRoomMember.Request.Queries;

namespace OnlineExam.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/class-room-members")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClassRoomMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassRoomMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateClassRoomMemberDTO createClassRoomMemberDTO)
        {
            await _mediator.Send(new CreateClassRoomMemberRequest() { CreateClassRoomMemberDTO = createClassRoomMemberDTO });
            return Created();
        }

        [HttpGet("{classId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int classId)
        {
            var result = await _mediator.Send(new GetClassRoomMemberByClassIdRequest() { ClassRoomId = classId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _mediator.Send(new GetClassRoomMemberRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpDelete("{classId}/{studentId}")]
        [Authorize]
        public async Task<IActionResult> Delete(int classId, string studentId)
        {
            await _mediator.Send(new DeleteClassRoomMemeberRequest() { ClassId = classId, StudentId = studentId });
            return NoContent();
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put(UpdateClassRoomMemberDTO updateClassRoomMemberDTO)
        {
            await _mediator.Send(new UpdateClassRoomMemberRequest() { UpdateClassRoomMemberDTO = updateClassRoomMemberDTO });
            return NoContent();
        }

        [HttpGet("{classId}/students")]
        [Authorize]
        public async Task<IActionResult> GetStudents(int classId)
        {
            var result = await _mediator.Send(new GetClassRoomMemberTeacherRequest() { ClassId = classId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
