using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.MultipleChoiceQuestion
{
    public class GetMultipleChoiceQuestionStudentDTO : BaseDTO
    {
        public List<string>? Choices { get; set; }

    }
}
