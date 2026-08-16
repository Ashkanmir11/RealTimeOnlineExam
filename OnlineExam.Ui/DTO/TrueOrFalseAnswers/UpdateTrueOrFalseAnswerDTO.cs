using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class UpdateTrueOrFalseAnswerDTO 
    {
        public bool StudentAnswer { get; set; }
        public int ExamId { get; set; }

    }
}
