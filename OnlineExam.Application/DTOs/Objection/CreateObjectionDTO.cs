using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection
{
    public class CreateObjectionDTO
    {
        public string? StudentText { get; set; }
        //Relations
        [JsonIgnore]
        public string? StudentId { get; set; }
        public int ExamId { get; set; }
    }
}
