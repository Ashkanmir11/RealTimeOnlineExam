using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class DescriptiveQuestion : BaseModel
    {
        public string? CorrectAnswer { get; set; }

        //Relation
        public List<DescriptiveAnswers>? Answers { get; set; }
        public List<Question>? Question { get; set; }
    }
}
