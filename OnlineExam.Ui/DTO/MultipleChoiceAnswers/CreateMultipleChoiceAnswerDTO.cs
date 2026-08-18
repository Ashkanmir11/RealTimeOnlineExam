using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class CreateMultipleChoiceAnswerDTO 
    {
        public int ExamId { get; set; }
        public int? StudentChoice { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
    }
}
