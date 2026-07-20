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
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ExamRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> IsUserTeacher(string UserId, int ExamId)
        {
            var exam=await _context.Exams.Where(e=>e.Id== ExamId).SingleOrDefaultAsync();
            return await _context.ClassRooms.AnyAsync(e => e.Id == exam.ClassId && e.TeacherId == UserId);
        }

    }
}
