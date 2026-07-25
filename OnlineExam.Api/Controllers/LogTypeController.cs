using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineExam.Api.Herlpers;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Features.LogType.Reqeust.Commands;
using OnlineExam.Application.Features.LogType.Reqeust.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTypeController : ControllerBase
    {
        private readonly IMediator _meditor;
        public LogTypeController(IMediator mediator)
        {
            _meditor = mediator;
        }
        [HttpPost("Post")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post(CreateLogTypeDTO createLogTypeDTO)
        {
            await _meditor.Send(new CreateLogTypeRequest() { CreateLogTypeDTO = createLogTypeDTO });
            return Created();
        }

        [HttpGet("Get")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get([FromQuery] PaginateRequestDTO paginateRequestDTO)
        {
            var result = await _meditor.Send(new GetLogTypeRequest() { PaginateRequestDTO = paginateRequestDTO });
            if (result.Data.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpGet("Get/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _meditor.Send(new GetLogTypeByIdRequest() { Id = id });
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _meditor.Send(new DeleteLogTypeRequest() { Id = id });
            return NoContent();
        }
        [HttpPut("Put")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateLogTypeDTO updateLogTypeDTO)
        {
            await _meditor.Send(new UpdateLogTypeRequest() { UpdateLogTypeDTO = updateLogTypeDTO });
            return NoContent();
        }

    }
}
