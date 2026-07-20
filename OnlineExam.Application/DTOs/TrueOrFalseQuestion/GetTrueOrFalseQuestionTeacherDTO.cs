using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion
{
    public class GetTrueOrFalseQuestionTeacherDTO : BaseDTO
    {
        public bool CorrectAnswer { get; set; }
        public GetTrueOrFalseAnswerTeacherDTO? Answer {  get; set; }


    }
}
