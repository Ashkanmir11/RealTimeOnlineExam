using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamLogRepository:IGenericRepository<ExamLog>
    {
        Task<List<GetExamLogDTO>> GetForTeacher(string studentId, int examId);
    }
}
