using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.AIServices
{
    public interface IAiServices
    {
        Task<decimal> GetScore(string StudentText, string CorrectText, decimal Score);
    }
}
