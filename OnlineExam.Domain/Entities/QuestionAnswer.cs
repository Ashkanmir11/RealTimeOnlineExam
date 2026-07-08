using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class QuestionAnswer : BaseModel
    {
        public string? Answer { get; set; }

        //Relations
        public int QuestionId { get; set; }
        public Question? Question { get; set; }

        public string? StudentId {  get; set; }

    }
}
