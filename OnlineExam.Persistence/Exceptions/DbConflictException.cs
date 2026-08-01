using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Exceptions
{
    public class DbConflictException : ApplicationException
    {
        public DbConflictException(string massage) : base(massage)
        {
        }
    }
}
