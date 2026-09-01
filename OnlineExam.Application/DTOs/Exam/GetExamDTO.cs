using OnlineExam.Application.DTOs.ClassRoom;

namespace OnlineExam.Application.DTOs.Exam
{
    public class GetExamDTO
    {
        public int QuestionCount { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AllowedDelay { get; set; }
        public bool AllowedCopy { get; set; } = false;
        public bool RandomQuestions { get; set; } = false;

        //Relation
        public GetClassRoomDTO? ClassRoom { get; set; }
    }
}
