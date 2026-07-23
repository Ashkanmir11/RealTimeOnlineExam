using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class ClassRoomRepository : GenericRepository<ClassRoom>, IClassRoomRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ClassRoomRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> IsUserTeacherAsync(int classId, string userId)
        {
            return await _context.ClassRooms.AnyAsync(e => e.Id == classId && e.TeacherId == userId);
        }

        public async Task<bool> IsUserTeacherByExamIdAsync(int examId,string teacherId)
        {
            var classId = await _context.Exams.Where(e => e.Id == examId).Select(e => e.ClassId).SingleOrDefaultAsync();
            return await _context.ClassRooms.AnyAsync(e => e.Id == classId && e.TeacherId == teacherId);
        }
    }
}
