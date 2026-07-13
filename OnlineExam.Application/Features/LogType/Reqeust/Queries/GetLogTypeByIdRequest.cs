using MediatR;
using OnlineExam.Application.DTOs.LogType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.LogType.Reqeust.Queries
{
    public class GetLogTypeByIdRequest : IRequest<GetLogTypeDTO>
    {
        public int Id {  get; set; }
    }
}
