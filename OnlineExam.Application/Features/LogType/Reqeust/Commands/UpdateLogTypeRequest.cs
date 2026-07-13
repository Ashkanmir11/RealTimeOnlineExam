using MediatR;
using OnlineExam.Application.DTOs.LogType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Reqeust.Commands
{
    public class UpdateLogTypeRequest:IRequest
    {
        public required UpdateLogTypeDTO UpdateLogTypeDTO { get; set; }
    }
}
