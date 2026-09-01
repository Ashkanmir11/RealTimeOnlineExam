using OnlineExam.Application.DTOs.Common;


namespace OnlineExam.Application.DTOs.ClassRoom
{
    public class GetClassRoomDTO : BaseDTO
    {
        public string? ClassName { get; set; }

        //Relations
        public string? TeacherId { get; set; }
        public List<Domain.Entities.Exam>? Exams { get; set; }
    }
}
