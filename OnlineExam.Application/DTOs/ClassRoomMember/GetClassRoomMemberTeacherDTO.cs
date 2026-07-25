using OnlineExam.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class GetClassRoomMemberTeacherDTO
    {
        public string? ClassName {  get; set; }
        public List <GetUserDTO>? Students { get; set; }
    }
}
