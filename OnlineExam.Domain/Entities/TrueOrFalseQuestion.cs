using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class TrueOrFalseQuestion : CommonQuestionTypeModel
    {
        public bool CorrectAnswer { get; set; }

        //Relations
        public List<TrueOrFalseAnswers>? Answers { get; set; }
    }
}
