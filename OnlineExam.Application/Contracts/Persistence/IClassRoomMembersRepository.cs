using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IClassRoomMembersRepository : IGenericRepository<ClassRoomMembers>
    {
        Task<bool> AddMembersAsync(CreateClassRoomMemberDTO createClassRoomMemberDTO);
        Task<bool> StudentIsInClassByExamIdAsync(string studentId, int examId);
        Task<List<string>> GetStudentByClassIdAsync(int classId);
        Task<bool> StudentIsInClassAsync(string studentId, int classId);
        Task<bool> UpdateClassRoomAsync(UpdateClassRoomMemberDTO updateClassRoomMemberDTO);
        Task<bool> DeleteAllClassRoomIdsAsync(List<string> studentIds, int classRoomId);
    }

}
