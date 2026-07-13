using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.LogType;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Reqeust.Queries
{
    public class GetLogTypeRequest : IRequest<PaginateResponse<GetLogTypeDTO>>
    {
        public required PaginateRequestDTO PaginateRequestDTO { get; set; }
    }
}
