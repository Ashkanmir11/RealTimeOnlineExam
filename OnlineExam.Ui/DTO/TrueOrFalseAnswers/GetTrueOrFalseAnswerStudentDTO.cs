using OnlineExam.Ui.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Ui.DTO.TrueOrFalseAnswers
{
    public class GetTrueOrFalseAnswerStudentDTO : BaseDTO
    {
        public bool StudentAnswer { get; set; }
    }
}
