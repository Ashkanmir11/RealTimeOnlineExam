using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Request.Commands
{
    public class DeleteOnjectionRequest : IRequest
    {
        public int Id { get; set; }
    }
}
