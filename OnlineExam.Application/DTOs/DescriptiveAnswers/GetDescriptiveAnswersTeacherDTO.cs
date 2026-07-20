using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers
{
    public class GetDescriptiveAnswersTeacherDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } 

    }
}
