using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Model
{
    public class GetTokens
    {
        public string? RefreshToken {  get; set; }
        public string? AccessToken {  get; set; }
    }
}
