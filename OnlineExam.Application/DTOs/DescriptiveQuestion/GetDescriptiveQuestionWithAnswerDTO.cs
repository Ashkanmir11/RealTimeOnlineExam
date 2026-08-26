using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class GetDescriptiveQuestionWithAnswerDTO : BaseDTO
    {
        public string? CorrectAnswer { get; set; }
        public GetDescriptiveAnswersTeacherDTO? Answer { get; set; }
    }
}
