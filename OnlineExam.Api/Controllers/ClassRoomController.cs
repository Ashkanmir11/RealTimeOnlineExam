using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using OnlineExam.Api.Herlpers;

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
        public async Task<IActionResult> Post(CreateClassRoomDTO createClassRoomDTO)
        {
            var result = await _mediator.Send(new CreateClassRoomRequest() { CreateClassRoomDTO = createClassRoomDTO });
            return Ok(ResponseHelper<GetClassRoomDTO>.Success(result, 200));
        }
    }
}
