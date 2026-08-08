using System.ComponentModel.DataAnnotations;
using OnlineExam.Ui.Validation;
namespace OnlineExam.Ui.DTO.Exam
{
    public class CreateExamDTO
    {
        [Required(ErrorMessage ="تعداد سوال نباید خالی باشد.")]
        [Range(0,999,ErrorMessage ="تعداد سوال باید بین {1} و {2} باشد.")]
        public int QuestionCount { get; set; }

        [Required(ErrorMessage = "نام آزمون نباید خالی باشد.")]
        [MaxLength(150,ErrorMessage ="نام آزمون نباید بیشتر از {1} کاراکتر باشد.")]
        public string? Name { get; set; }

        [MaxLength(500,ErrorMessage ="توضیحات نباید بیشتر از {1} کاراکتر باشد.")]
        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Range(1,999,ErrorMessage ="میزان تاخیر باید بین {1} و {2} باشد.")]
        public int AllowedDelay { get; set; }
        public bool AllowedCopy { get; set; } = false;
        public bool LogStudent { get; set; } = true;
        public bool RandomQuestions { get; set; } = false;
        public int? ClassId { get; set; }

    }
}
