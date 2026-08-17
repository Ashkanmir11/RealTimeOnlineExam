using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.DescriptiveAnswers
{
    public class UpdateDescriptiveAnswersDTO 
    {
        public string? StudentAnswer { get; set; }
        public int ExamId { get; set; }


    }
}
