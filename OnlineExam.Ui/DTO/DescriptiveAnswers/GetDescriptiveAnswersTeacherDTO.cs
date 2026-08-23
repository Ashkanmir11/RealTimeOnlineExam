
using OnlineExam.Ui.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTO.DescriptiveAnswers
{
    public class GetDescriptiveAnswersTeacherDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } 

    }
}
