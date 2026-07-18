using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;
using System.Text.Json.Serialization;
namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion
{
    public class GetTrueOrFalseQuestionDTO : BaseDTO
    {
        public bool CorrectAnswer { get; set; }

    }
}
