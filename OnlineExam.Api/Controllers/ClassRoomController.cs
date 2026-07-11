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
            return Ok(ResponseHelper<GetClassRoomDTO>.Success(result, 200));
        }
        [HttpGet("Get/{Id}")]
        [Authorize]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _mediator.Send(new GetClassRoomByIdRequest() { Id = Id });
            if (response == null)
            {
                return NoContent();
            }
            return Ok(ResponseHelper<GetClassRoomDTO>.Success(response, 200));
        }
        [HttpGet("Get")]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var response = await _mediator.Send(new GetClassRoomRequest() { PaginateRequest = paginateRequestDTO });
            if (response.Data.Count == 0 || response.Data == null)
            {
                return NoContent();
            }
            return Ok (ResponseHelper<PaginateResponse<GetClassRoomDTO>>.Success(response, 200));
        }
    }
}
