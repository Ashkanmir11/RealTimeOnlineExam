using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Request.Queries
{
    public class GetClassRoomByIdRequest : IRequest<GetClassRoomDTO>
    {
        public int Id { get; set; }
    }
}
