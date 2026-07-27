using MediatR;
using OnlineExam.Application.DTOs.Objection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Objection.Request.Commands
{
    public class UpdateObjectionRequest : IRequest
    {
        public int Id { get; set; }
        public required UpdateObjectionDTO UpdateObjectionDTO { get; set; }
    }
}
