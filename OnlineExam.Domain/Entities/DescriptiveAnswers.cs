using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class DescriptiveAnswers : CommonQuestionAnswerModel
    {
        public string? StudentAnswer {  get; set; }

        //Relations
        public int DescriptiveQuestionId { get; set; }
        public DescriptiveQuestion? DescriptiveQuestion { get; set; }
    }
}
