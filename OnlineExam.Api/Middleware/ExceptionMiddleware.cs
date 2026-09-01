using OnlineExam.Api.Herlpers;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Response;
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

                if (ex is ValidationException validationException)
                {
                    await httpContext.Response.WriteAsJsonAsync(new ErrorResponse
                    {
                        Errors = validationException.Errors
                    });

                    return;
                }

                await httpContext.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    Errors = new List<string> { ex.Message }
                });
            }
        }
    }
}
