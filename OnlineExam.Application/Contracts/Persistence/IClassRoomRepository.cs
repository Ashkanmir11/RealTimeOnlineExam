using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
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
        Task<PaginateResponse<GetClassRoomTeacherDTO>> GetTeacherClassAsync(string teacherId ,PaginateRequestDTO paginateRequestDTO);
        Task<PaginateResponse<GetClassRoomStudentDTO>> GetStudentClassesAsync(string studentId, PaginateRequestDTO paginateRequestDTO);
    }

}
