using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class MultipleChoiceQuestionAnswers : CommonQuestionAnswerModel
    {
        public int? StudentChoice { get; set; }
        //Relations
        public int MultipleChoiceQuestionId { get; set; }
        public MultipleChoiceQuestion? MultipleChoiceQuestion { get; set; }


    }
}
