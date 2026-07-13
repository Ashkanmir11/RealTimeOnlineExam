using OnlineExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Exam
{
    public class GetExamDTO
    {
        public int QuestionCount { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTimeOffset? AllowedDelay { get; set; }
        public bool Ended { get; set; } = false;
        public bool AllowedCopy { get; set; } = false;

        public bool LogStudent { get; set; } = true;
        public bool RandomQuestions { get; set; } = false;

        //Relation
        public GetClassRoomDTO? ClassRoom { get; set; }
    }
}
