using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestionAnswers
{
    public class UpdateDescriptiveQuestionAnswersDTO : BaseDTO
    {
        public string? StudentAnswer { get; set; }
    }
}
