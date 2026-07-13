using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoom
{
    public class CreateClassRoomDTO
    {
        public string? ClassName {  get; set; }

        [JsonIgnore]
        public string? TeacherId {  get; set; }
    }
}
