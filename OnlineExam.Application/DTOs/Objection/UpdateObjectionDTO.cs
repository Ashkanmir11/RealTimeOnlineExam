namespace OnlineExam.Application.DTOs.Objection
{
    public class UpdateObjectionDTO
    {
        public string? StudentText { get; set; }
        public string? TeacherComment { get; set; }
        public bool Accepted { get; set; } = false;

    }
}
