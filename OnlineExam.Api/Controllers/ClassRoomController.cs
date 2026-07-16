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
        private readonly IAuthServices _authServices;
        public ClassRoomController(IMediator mediator, IAuthServices authServices)
        {
            _mediator = mediator;
            _authServices = authServices;
        }
        [HttpPost("Post")]
        [Authorize]
        public async Task<IActionResult> Post(CreateClassRoomDTO createClassRoomDTO)
        {
            ////Un comment if need to get added entity
            //createClassRoomDTO.TeacherId=await _authServices.GetCurrentUserId();
            //var result = await _mediator.Send(new CreateClassRoomRequest() { CreateClassRoomDTO = createClassRoomDTO });
            //return Ok(ResponseHelper<GetClassRoomDTO>.Success(result, 200));

            createClassRoomDTO.TeacherId = await _authServices.GetCurrentUserId();
            var result = await _mediator.Send(new CreateClassRoomRequest() { CreateClassRoomDTO = createClassRoomDTO });
            return Created();
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
            return Ok(response);
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
            return Ok(response);
        }

        [HttpDelete("Delete/{Id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            var currentUser = await _authServices.GetCurrentUserId();
            await _mediator.Send(new DeleteClassRoomRequest() { Id = Id, UserId = currentUser });
            return NoContent();
        }


        [HttpPut("Put")]
        [Authorize]
        public async Task<IActionResult> Put(UpdateClassRoomDTO updateClassRoomDto)
        {
            var currentUserId = await _authServices.GetCurrentUserId();
            await _mediator.Send(new UpdateClassRoomRequest() { UpdateClassRoomDTO = updateClassRoomDto, UserId = currentUserId });
            return Ok();
        }



    }
}
