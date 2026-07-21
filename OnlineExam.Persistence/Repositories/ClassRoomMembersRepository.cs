using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoomMember;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;

namespace OnlineExam.Persistence.Repositories
{
    public class ClassRoomMembersRepository : GenericRepository<ClassRoomMembers>, IClassRoomMembersRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ClassRoomMembersRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> AddMembersAsync(CreateClassRoomMemberDTO createClassRoomMemberDTO)
        {
            var newClassStudent = new List<ClassRoomMembers>();
            foreach (var classRoomMember in createClassRoomMemberDTO.StudentIDs)
            {
                newClassStudent.Add(new ClassRoomMembers()
                {
                    ClassRomeId = createClassRoomMemberDTO.ClassRomeId,
                    StudentId = classRoomMember
                });
            }
            await _context.ClassRoomMembers.AddRangeAsync(newClassStudent);
            await _context.SaveChangesAsync();
            return true;

        }



        public async Task<List<string>> GetStudentByClassIdAsync(int classId)
        {
            var classMembers = await _context.ClassRoomMembers.Where(e => e.ClassRomeId == classId).Select(e => e.StudentId).ToListAsync();
            return classMembers;
        }

        public async Task<bool> UpdateClassRoomAsync( UpdateClassRoomMemberDTO updateClassRoomMemberDTO)
        {
            var oldClassMembers = await _context.ClassRoomMembers.Where(e => e.ClassRomeId == updateClassRoomMemberDTO.ClasRoomId).Select(e => e.StudentId).ToListAsync();
            await DeleteAllClassRoomIds(oldClassMembers, updateClassRoomMemberDTO.ClasRoomId);
            await AddMembersAsync(new CreateClassRoomMemberDTO()
            {
                StudentIDs = updateClassRoomMemberDTO.StudentIDs,
                ClassRomeId = updateClassRoomMemberDTO.ClasRoomId
            });
            return true;
        }
        public Task<bool> DeleleAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteAllClassRoomIds(List<string> studentIds, int classRoomId)
        {
            var delete = await _context.ClassRoomMembers.Where(e => studentIds.Contains(e.StudentId) && e.ClassRomeId == classRoomId).ToListAsync();
            _context.ClassRoomMembers.RemoveRange(delete);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> StudentIsInClassByExamId(string studentId,int examId)
        {
            var examClassId =await _context.Exams.Where(e => e.Id == examId).Select(e => e.ClassId).SingleOrDefaultAsync();
            return await _context.ClassRoomMembers.AnyAsync(e => e.ClassRomeId == examClassId && e.StudentId == studentId);
        }
        public async Task<bool> StudentIsInClassAsync(string studentId, int classId)
        {
           return await _context.ClassRoomMembers.AnyAsync(e=>e.ClassRomeId==classId&& e.StudentId==studentId);
        }
    }
}
