using OnlineExam.Application.DTOs.Common;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection
{
    public class UpdateObjectionDTO 
    {
        public string? StudentText { get; set; }
        public string? TeacherComment { get; set; }
        public bool Accepted { get; set; } = false;

    }
}
