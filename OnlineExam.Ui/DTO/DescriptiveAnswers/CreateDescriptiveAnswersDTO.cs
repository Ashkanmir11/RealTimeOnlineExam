using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.DescriptiveAnswers
{
    public class CreateDescriptiveAnswersDTO 
    {
        public int ExamId { get; set; }
        public string? StudentAnswer { get; set; }
        public int DescriptiveQuestionId { get; set; }
    }
}
