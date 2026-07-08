using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class DescriptiveQuestionAnswers : CommonQuestionAnswerModel
    {
        public string? StudentAnswer {  get; set; }

        //Relations
        public int descriptiveQuestionAnswersId { get; set; }
        public DescriptiveQuestion? DescriptiveQuestion { get; set; }
    }
}
