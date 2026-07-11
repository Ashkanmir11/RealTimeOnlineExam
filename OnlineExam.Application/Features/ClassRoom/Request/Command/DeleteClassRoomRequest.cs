using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Request.Command
{
    public class DeleteClassRoomRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string UserId {  get; set; }
    }
}
