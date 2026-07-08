using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Question : BaseModel
    {
        public string? QuestionText { get; set; }
        public string? CorrectAnswer { get; set; }
        public string? StudentAnswer { get; set; }
        public int? TotalScore { get; set; }
        public int? StudnetScore { get; set; }
        //Relations
        public int? QuestionTypeId { get; set; }
        public QuestionType? QuestionType { get; set; }
        public List<QuestionAnswer>? QuestionAnswers { get; set; }
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
