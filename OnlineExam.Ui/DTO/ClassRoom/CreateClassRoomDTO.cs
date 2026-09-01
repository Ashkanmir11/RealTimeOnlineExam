using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Ui.DTO.ClassRoom
{
    public class CreateClassRoomDTO
    {
        [Required(ErrorMessage = "نام کلاس نباید خالی باشد.")]
        [MaxLength(150, ErrorMessage = "نام کلاس نباید بیشتر از {1} کاراکتر باشد")]
        public string? ClassName { get; set; }
    }
}
