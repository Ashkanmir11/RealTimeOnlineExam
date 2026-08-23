using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class UpdateMultipleChoiceAnswerTeacherDTO 
    {
        public decimal? StudentScore { get; set; }
        public int ExamId { get; set; }
    }
}
