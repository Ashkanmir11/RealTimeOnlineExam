using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoomMember
{
    public class UpdateClassRoomMemberDTO
    {
        public int ClasRoomId {  get; set; }
        public List<string>? Phones { get; set; }

        [JsonIgnore]
        public List<string>? StudentIDs { get; set; }
    }
}
