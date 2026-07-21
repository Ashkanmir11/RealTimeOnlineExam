using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamAttamptRepository : IGenericRepository<ExamAttampt>
    {
        Task<bool> ExamEndedAsync(int examId, string userId);
        Task<bool> ExamStartedAsync(int examId, string userId);
        Task EndExamAsync(int examId , string userId);
    }
}
