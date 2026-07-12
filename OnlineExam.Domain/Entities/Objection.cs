using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Objection : BaseModel
    {
        public string? StudentText {  get; set; }
        public string? TeacherComment {  get; set; }
        public bool Accepted { get; set; } = false;

        //Relations
        public string? StudentId {  get; set; }
        public int ExamId {  get; set; }
        public Exam? Exam {  get; set; }


    }
}
