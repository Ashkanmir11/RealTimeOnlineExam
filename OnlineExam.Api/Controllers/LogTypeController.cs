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
    [Route("api/log-types")]
    [ApiController]
    public class LogTypeController : ControllerBase
    {
        private readonly IMediator _meditor;
        public LogTypeController(IMediator mediator)
        {
            _meditor = mediator;
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post(CreateLogTypeDTO createLogTypeDTO)
        {
            await _meditor.Send(new CreateLogTypeRequest() { CreateLogTypeDTO = createLogTypeDTO });
            return Created();
        }

        [HttpGet]
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

        [HttpGet("{id}")]
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
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _meditor.Send(new DeleteLogTypeRequest() { Id = id });
            return NoContent();
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id,UpdateLogTypeDTO updateLogTypeDTO)
        {
            await _meditor.Send(new UpdateLogTypeRequest() { UpdateLogTypeDTO = updateLogTypeDTO ,Id=id});
            return NoContent();
        }

    }
}
