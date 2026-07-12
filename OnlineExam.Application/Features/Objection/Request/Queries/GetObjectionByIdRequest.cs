using MediatR;
using OnlineExam.Application.DTOs.Objection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Request.Queries
{
    public class GetObjectionByIdRequest : IRequest<GetObjectionDTO>
    {
        public int Id { get; set; }
    }
}
