using OnlineExam.Domain.Common;
using OnlineExam.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class ClassRoom : BaseModel
    {
        public string? ClassName { get; set; }

        //Relations
        public string? TeacherId { get; set; }
        public List<Exam>? Exams {  get; set; }
        //public List<OnlineExamUser>? Students { get; set; }
        //public OnlineExamUser? Teacher { get; set; }
    }
}
