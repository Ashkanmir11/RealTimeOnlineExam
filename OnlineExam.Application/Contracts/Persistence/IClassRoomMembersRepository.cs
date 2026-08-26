using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Application.Contracts.Persistence
{
    public interface IClassRoomMembersRepository
    {
        Task<bool> AddMembersAsync(CreateClassRoomMemberDTO createClassRoomMemberDTO);
        Task<bool> StudentIsInClassByExamIdAsync(string studentId, int examId);
        Task<List<string>> GetStudentByClassIdAsync(int classId);
        Task<bool> StudentIsInClassAsync(string studentId, int classId);
        Task<bool> UpdateClassRoomAsync(UpdateClassRoomMemberDTO updateClassRoomMemberDTO);
        Task<bool> DeleteAllClassRoomIdsAsync(List<string> studentIds, int classRoomId);
        Task<bool> ExistAsync(int classId, string UserId);
        Task DeleleAsync(ClassRoomMembers classRoomMembers);
        Task<ClassRoomMembers> GetAsync(int classId, string userId);


    }

}
