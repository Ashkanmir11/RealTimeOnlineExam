using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class TrueOrFalseQuestionAnswers : CommonQuestionAnswerModel
    {
        public bool StudentAnswer {  get; set; }
        //Relations
        public int TrueOrFalseQuestionId {  get; set; }
        public TrueOrFalseQuestion? TrueOrFalseQuestion { get; set; }

    }
}
