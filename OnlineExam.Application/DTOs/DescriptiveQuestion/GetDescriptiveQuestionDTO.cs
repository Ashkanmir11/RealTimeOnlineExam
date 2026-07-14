using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.DescriptiveQuestion
{
    public class GetDescriptiveQuestionDTO : CommonQuestionTypeModel
    {
        public string? CorrectAnswer { get; set; }
    }
}
