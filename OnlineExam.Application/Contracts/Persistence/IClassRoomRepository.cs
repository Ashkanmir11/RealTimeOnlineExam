using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IClassRoomRepository : IGenericRepository<ClassRoom>
    {
        Task<bool> IsUserTeacherByExamIdAsync(int examId,string teacherId);
        Task<bool> IsUserTeacherAsync(int classId,string userId);
    }
}
