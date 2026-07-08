using OnlineExam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class ClassRoom : BaseDTO
    {
        public string? ClassName { get; set; }
        public string? TeacherId { get; set; }
    }
}
