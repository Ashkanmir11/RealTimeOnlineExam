using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class QuestionType : BaseModel
    {
        public string? TypeName { get; set; }

        //Relations
        public List<Question>? Questions { get; set; }
    }
}
