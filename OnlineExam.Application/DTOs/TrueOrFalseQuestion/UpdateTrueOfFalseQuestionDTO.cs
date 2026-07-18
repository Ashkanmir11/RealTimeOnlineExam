using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.TrueOrFalseQuestion
{
    public class UpdateTrueOfFalseQuestionDTO : BaseDTO
    {
        public bool CorrectAnswer { get; set; }
    }
}
