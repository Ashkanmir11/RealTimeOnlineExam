using OnlineExam.Domain.Common;
using OnlineExam.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Entities
{
    public class Objection : BaseModel
    {
        public string? Comment {  get; set; }
        public bool Accepted { get; set; } = false;

        public string? TeacherId {  get; set; }
        public string? StudentId {  get; set; }
        //Relations
        //public string? StudentId {  get; set; }
        //public OnlineExamUser? student {  get; set; }

        //public string?TeacherId { get; set; }
        //public OnlineExamUser? Teacher { get; set; }

    }
}
