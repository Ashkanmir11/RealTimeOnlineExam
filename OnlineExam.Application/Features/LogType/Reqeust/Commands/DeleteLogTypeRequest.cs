using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Reqeust.Commands
{
    public class DeleteLogTypeRequest : IRequest
    {
        public int Id { get; set; }
    }
}
