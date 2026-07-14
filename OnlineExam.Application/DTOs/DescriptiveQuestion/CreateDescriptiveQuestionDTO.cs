using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class CreateDescriptiveQuestionDTO
    {
        public string? QuestionText { get; set; }
        public int? TotalScore { get; set; }
        public int ExamId { get; set; }
        public string? CorrectAnswer { get; set; }

    }
}
