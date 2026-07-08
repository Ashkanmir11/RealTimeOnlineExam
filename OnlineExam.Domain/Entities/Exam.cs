using OnlineExam.Domain.Common;
using OnlineExam.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Exam : BaseModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTimeOffset? AllowedDelay { get; set; }
        public bool Ended {  get; set; }= false;
        public bool AllowedCopy { get; set; } = false;

        public bool LogStudent { get; set; } = true;

        //Relation
        public List<Question>? Questions { get; set; }
        public List<OnlineExamUser>? Students { get; set; }
        public OnlineExamUser? Teacher { get; set; }

    }
}
