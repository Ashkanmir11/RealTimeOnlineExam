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
        Task<bool> StudentIsInClassByExamId(string studentId, int examId);
        Task<List<string>> GetStudentByClassIdAsync(int ClassId);
        Task<bool> StudentIsInClassAsync(string StudentId, int ClassId);
        Task<bool> UpdateClassRoomAsync(UpdateClassRoomMemberDTO updateClassRoomMemberDTO);
        Task<bool> DeleteAllClassRoomIds(List<string> studentIds, int classRoomId);
    }

}
