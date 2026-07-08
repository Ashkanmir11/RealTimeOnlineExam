using Microsoft.AspNetCore.Identity;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Model
{
    public class OnlineExamUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? NationalCode { get; set; }

        //Relations
        public List<RefreshToken>? RefreshTokens { get; set; }
        public List<ClassRoom>? classRooms { get; set; }
        public List<Objection>? StudentObjection { get; set; }
        public List<Objection>? TeacherObjection { get; set; }
    }
}
