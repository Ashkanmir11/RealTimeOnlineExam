using OnlineExam.Ui.DTO.LogType;

namespace OnlineExam.Ui.DTO.ExamLog
{
    public class GetExamLogDTO
    {
        public int Id { get; set; }
        public string? LogDescription { get; set; }
        public GetLogTypeDTO? LogType { get; set; }
    }
}
