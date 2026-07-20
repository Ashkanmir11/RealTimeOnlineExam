using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;

namespace OnlineExam.Application.DTOs.MultipleChoiceAnswers
{
    public class GetMultipleChoiceAnswerDTO : BaseDTO
    {
        public int? StudentChoice { get; set; }
        [JsonIgnore]
        public string? StudentId { get; set; }
        public GetUserDTO? User { get; set; }
        public decimal StudentScore { get; set; } 
        public GetMultipleChoiceQuestionDTO? MultipleChoiceQuestion { get; set; }
    }
}
