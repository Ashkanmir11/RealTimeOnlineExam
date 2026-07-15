using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class GetClassRoomMemberDTO
    {
        public List<UserNameAndLastNameDTO>? Students { get;set; }
        public GetClassRoomDTO? GetClassRoomDTO { get; set; }
    }
}
