namespace OnlineExam.Ui.DTO.Common
{
    public class PaginateRequestDTO
    {
        public int PageNumber { get; set; } = 1;
        public int PageCount { get; set; } = 10;
        public string? SortBy { get; set; } = "Id";
        public bool Descending { get; set; } = true;
    }
}
