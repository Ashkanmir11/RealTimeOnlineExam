using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class CreateTrueOrFalseAnswerDTO 
    {
        public int ExamId { get; set; }
        public bool StudentAnswer { get; set; }
        public int TrueOrFalseQuestionId { get; set; }
    }
}
