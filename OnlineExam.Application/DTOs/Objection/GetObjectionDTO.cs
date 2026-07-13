using OnlineExam.Application.DTOs.Common;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection
{
    public class GetObjectionDTO : BaseDTO
    {
        public string? Comment { get; set; }
        public bool Accepted { get; set; } = false;

        //Relations
        public string? StudentId { get; set; }
        public Domain.Entities.Exam? Exam { get; set; }
    }
}
