using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.MultipleChoiceAnswers
{
    public class UpdateMultipleChoiceAnswerDTO
    {
        public int? StudentChoice { get; set; }
        public int ExamId { get; set; }

    }
}
