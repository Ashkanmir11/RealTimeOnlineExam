using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExam.Api.Controllers.V2
{
    [Route("api/v{version:apiVersion}/tesr")]
    [ApiController]
    [ApiVersion("2.0")]
    public class v2test : ControllerBase
    {
        [HttpGet("test")]
        public async Task tesT()
        {
            throw new NotImplementedException();
        }
    }
}
