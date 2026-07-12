using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class CreateClassRoomMemberDTO
    {
        public List<string>? StudentIDs { get; set; }
        public int ClassRomeId { get; set; }
    }
}
