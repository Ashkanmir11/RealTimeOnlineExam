using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Common
{
    public class CommonQuestionTypeModel : BaseModel
    {
        public string? QuestionText { get; set; }
        public int? TotalScore { get; set; }
        //Relations
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
