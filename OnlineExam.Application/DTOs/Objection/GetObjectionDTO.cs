using OnlineExam.Application.DTOs.Common;

namespace OnlineExam.Application.DTOs.Objection
{
    public class GetObjectionDTO : BaseDTO
    {
        public string? Comment { get; set; }
        public bool Accepted { get; set; } = false;

        //Relations
        public string? StudentId { get; set; }
        public Domain.Entities.Exam? Exam { get; set; }
    }
}
