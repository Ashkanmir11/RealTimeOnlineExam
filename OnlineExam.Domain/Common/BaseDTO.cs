using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Domain.Common
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedDate {  get; set; }
        public DateTime ModifiedDate { get; set;}
    }
}
