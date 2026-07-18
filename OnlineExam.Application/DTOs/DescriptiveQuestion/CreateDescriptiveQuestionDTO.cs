using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class CreateDescriptiveQuestionDTO
    {
        public string? CorrectAnswer { get; set; }
    }
}
