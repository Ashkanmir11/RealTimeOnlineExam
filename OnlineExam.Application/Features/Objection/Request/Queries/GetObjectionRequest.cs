using MediatR;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Objection;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Request.Queries
{
    public class GetObjectionRequest : IRequest<PaginateResponse<GetObjectionDTO>>
    {
        public required PaginateRequestDTO PaginateRequest { get; set; }
    }
}
