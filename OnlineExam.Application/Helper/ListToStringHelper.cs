using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Helper
{
    public static class ListToStringHelper
    {
        public static string CreateString(List<string> list)
        {
            string result = "";
            for (int i = 0; i < list.Count; i++)
            {
                result = i+1 == list.Count ? result + list[i] : result + list[i]+ "-";
            }
            return result;
        }
    }
}
