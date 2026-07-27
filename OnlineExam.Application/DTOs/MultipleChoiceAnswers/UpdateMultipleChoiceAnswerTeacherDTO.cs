using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class UpdateMultipleChoiceAnswerTeacherDTO 
    {
        public int? StudentChoice { get; set; }
        public decimal? StudentScore { get; set; }
        public int ExamId { get; set; }
    }
}
