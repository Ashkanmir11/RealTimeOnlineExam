using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<bool> IsUserTeacherAsync(string userId, int examId);
        Task<PaginateResponse<GetExamDetailDTO>> GetByClassIdAsync(int classId,PaginateRequestDTO paginateRequestDTO);
    }
}
