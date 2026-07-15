using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestionAnswers
{
    public class CreateDescriptiveQuestionAnswersDTO
    {
        public string? StudentAnswer { get; set; }
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int descriptiveQuestionAnswersId { get; set; }
    }
}
