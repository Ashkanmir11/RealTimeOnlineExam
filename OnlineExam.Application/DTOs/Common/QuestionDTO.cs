using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Common
{
    public class QuestionDTO
    {
        public List<GetDescriptiveQuestionDTO>? DescriptiveQuestions { get; set; }
        public List<GetMultipleChoiceQuestionDTO>? MultipleChoiceQuestion { get; set; }
        public List<GetTrueOrFalseQuestionDTO>? TrueOrFalseQuestion { get; set; }

    }
}
