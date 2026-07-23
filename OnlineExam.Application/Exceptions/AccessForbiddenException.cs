using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Exceptions
{
    public class AccessForbiddenException : ApplicationException
    {
        public AccessForbiddenException(string massage) : base(massage)
        {
        }
    }
}
