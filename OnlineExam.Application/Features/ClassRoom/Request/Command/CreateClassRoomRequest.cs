using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class CreateClassRoomRequest : IRequest<GetClassRoomDTO>
    {
        public CreateClassRoomDTO? CreateClassRoomDTO { get; set; }
    }
}
