using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerTeacherDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
