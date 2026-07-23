using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Commands
{
    public class DeleteClassRoomMemeberRequest : IRequest
    {
        public int ClassId {  get; set; }
        public string? StudentId {  get; set; }
    }
}
