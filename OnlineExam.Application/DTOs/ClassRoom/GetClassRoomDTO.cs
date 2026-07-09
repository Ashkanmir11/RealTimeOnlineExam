using OnlineExam.Application.DTOs.Common;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoom
{
    public class GetClassRoomDTO : BaseDTO
    {
        public string? ClassName { get; set; }

        //Relations
        public string? TeacherId { get; set; }
        public List<Exam>? Exams { get; set; }
    }
}
