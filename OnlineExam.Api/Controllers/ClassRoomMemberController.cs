using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Features.ClassRoomMember.Request.Commands;
using OnlineExam.Application.Features.ClassRoomMember.Request.Queries;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoomMemberController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClassRoomMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post(CreateClassRoomMemberDTO createClassRoomMemberDTO)
        {
            await _mediator.Send(new CreateClassRoomMemberRequest() { CreateClassRoomMemberDTO = createClassRoomMemberDTO });
            return Created();
        }

        [HttpGet("Get/{ClassId}")]
        public async Task<IActionResult> Get(int ClassId)
        {
            var result = await _mediator.Send(new GetClassRoomMemberByClassIdRequest() { ClassRoomId = ClassId });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("Get")]
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

        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            throw new NotImplementedException();
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put(UpdateClassRoomMemberDTO updateClassRoomMemberDTO)
        {
            await _mediator.Send(new UpdateClassRoomMemberRequest() { UpdateClassRoomMemberDTO= updateClassRoomMemberDTO });
            return NoContent();
        }
    }
}
