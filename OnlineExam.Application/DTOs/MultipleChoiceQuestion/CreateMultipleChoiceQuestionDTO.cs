using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class CreateMultipleChoiceQuestionDTO
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice { get; set; }

    }
}
