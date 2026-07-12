using OnlineExam.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection
{
    public class UpdateObjectionDTO : BaseDTO
    {
        public string? Comment { get; set; }
        public bool Accepted { get; set; } = false;


    }
}
