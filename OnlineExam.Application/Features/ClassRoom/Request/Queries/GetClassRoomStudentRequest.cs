using MediatR;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ClassRoom.Request.Queries
{
    public class GetClassRoomStudentRequest : IRequest<PaginateResponse<GetClassRoomStudentDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
