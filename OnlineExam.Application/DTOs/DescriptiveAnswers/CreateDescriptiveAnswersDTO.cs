using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveAnswers
{
    public class CreateDescriptiveAnswersDTO
    {
        public string? StudentAnswer { get; set; }
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int DescriptiveAnswersId { get; set; }
        public int ExamId {  get; set; }
    }
}
