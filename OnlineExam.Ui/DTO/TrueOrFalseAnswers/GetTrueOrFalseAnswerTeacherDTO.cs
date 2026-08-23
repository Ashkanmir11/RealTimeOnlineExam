using OnlineExam.Ui.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerTeacherDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
        public decimal StudentScore { get; set; } = 0;

    }
}
