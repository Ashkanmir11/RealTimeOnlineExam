using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers
{
    public class CreateTrueOrFalseQuestionAnswerDTO
    {
        [JsonIgnore]
        public string? StudentId { get; set; }
        public bool StudentAnswer { get; set; }
        public int TrueOrFalseQuestionId { get; set; }
    }
}
