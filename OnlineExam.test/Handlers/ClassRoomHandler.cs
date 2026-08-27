using OnlineExam.Test.Models.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Handlers
{
    public class ClassRoomHandler
    {
        public bool Craete(CreateClassRoomDTO createClassRoomDTO)
        {
            if (createClassRoomDTO.ClassName != null && createClassRoomDTO.ClassName.Length < 1)
            {
                return false;
            }
            return true;
        }
    }
}
