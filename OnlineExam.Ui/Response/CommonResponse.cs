namespace OnlineExam.Ui.Response
{
    public class CommonResponse<T>
    {
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }

    }
}
