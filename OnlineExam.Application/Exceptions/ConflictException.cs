using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Exceptions
{
    public class ConflictException : ApplicationException
    {
        public ConflictException(string massage) : base(massage)
        {
        }
    }
}
