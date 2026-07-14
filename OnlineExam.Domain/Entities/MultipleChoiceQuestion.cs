using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class MultipleChoiceQuestion: CommonQuestionTypeModel
    {
        public List<string>? Choices { get; set; }
        public int CorrectChoice {  get; set; }

        //Relations
        public List<MultipleChoiceQuestionAnswers>? Answers { get; set; }
    }
}
