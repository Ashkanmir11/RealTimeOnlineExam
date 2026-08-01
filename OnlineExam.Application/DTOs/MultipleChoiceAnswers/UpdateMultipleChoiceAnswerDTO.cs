using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class UpdateMultipleChoiceAnswerDTO
    {
        [JsonIgnore]
        public int QuestionId { get; set; }
        public int? StudentChoice { get; set; }
        public int ExamId { get; set; }

    }
}
