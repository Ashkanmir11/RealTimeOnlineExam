using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Commands
{
    public class CreateClassRoomMemberRequest : IRequest
    {
        public required CreateClassRoomMemberDTO CreateClassRoomMemberDTO { get; set;}
    }
}
