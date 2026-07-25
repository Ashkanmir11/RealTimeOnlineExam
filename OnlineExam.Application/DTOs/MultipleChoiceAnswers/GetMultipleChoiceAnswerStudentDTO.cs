using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerStudentDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
    }
}
