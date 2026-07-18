using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class CreateMultipleChoiceAnswerDTO
    {
        public int? StudentChoice { get; set; }
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int MultipleChoiceQuestionId { get; set; }
        public int ExamId {  get; set; }
    }
}
