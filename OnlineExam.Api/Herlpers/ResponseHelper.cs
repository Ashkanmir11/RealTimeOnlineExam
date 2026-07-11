using OnlineExam.Application.Response;

namespace OnlineExam.Api.Herlpers
{
    public static class ResponseHelper<T>
    {
        public static CommonResponse<T> Success(T data, int status)
        {

            var result = new CommonResponse<T>()
            {
                Data = data,
                IsSuccess = true,
                StatusCode = status
            };
            return result;
        }
    

    }
}
