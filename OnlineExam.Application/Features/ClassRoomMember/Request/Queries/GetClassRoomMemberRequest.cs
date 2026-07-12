using MediatR;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoomMember.Request.Queries
{
    public class GetClassRoomMemberRequest : IRequest<List<GetClassRoomMemberDTO>>
    {
       public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
