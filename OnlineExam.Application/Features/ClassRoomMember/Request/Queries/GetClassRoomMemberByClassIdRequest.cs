using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Queries
{
    public class GetClassRoomMemberByClassIdRequest : IRequest<GetClassRoomMemberDTO>
    {
        public int ClassRoomId {  get; set; }
    }
}
