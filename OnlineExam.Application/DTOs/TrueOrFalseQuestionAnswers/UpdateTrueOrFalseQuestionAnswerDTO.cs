using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers
{
    public class UpdateTrueOrFalseQuestionAnswerDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
    }
}
