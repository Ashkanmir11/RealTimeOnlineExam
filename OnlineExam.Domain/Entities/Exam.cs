using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Exam : BaseModel
    {
        public int QuestionCount {  get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTimeOffset? AllowedDelay { get; set; }
        public bool Ended {  get; set; }= false;
        public bool AllowedCopy { get; set; } = false;

        public bool LogStudent { get; set; } = true;
        public bool RandomQuestions {  get; set; } = false;
        //Relation
        public int ClassId {  get; set; }
        public ClassRoom? ClassRoom { get; set; }
        public List<Question>? Questions { get; set; }

        public List<ExamLog>? ExamLog { get; set; }


    }
}
