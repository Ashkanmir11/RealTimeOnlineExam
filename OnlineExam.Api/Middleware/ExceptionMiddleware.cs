using OnlineExam.Application.Response;
using OnlineExam.Api.Herlpers;
namespace OnlineExam.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = ExceptionCodeHelper.ExceptionMap(ex);

                await httpContext.Response.WriteAsJsonAsync(new CommonResponse<object>
                {
                    IsSuccess = false,
                    StatusCode = httpContext.Response.StatusCode,
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}
