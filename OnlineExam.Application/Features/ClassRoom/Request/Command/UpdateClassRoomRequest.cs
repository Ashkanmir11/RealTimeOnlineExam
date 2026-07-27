using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class UpdateClassRoomRequest : IRequest
    {
        public int Id {  get; set; }
        public UpdateClassRoomDTO? UpdateClassRoomDTO { get; set; }
    }
}
