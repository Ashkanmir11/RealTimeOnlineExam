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
    public class ExamAttamptRepository : GenericRepository<ExamAttampt>, IExamAttamptRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ExamAttamptRepository(OnlineExamDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ExamEndedAsync(int ExamId, string UserId)
        {
            return await _context.ExamAttampts.Where(e => e.ExamId == ExamId && e.StudentId == UserId).Select(e => e.IsEnded).SingleOrDefaultAsync();
        }

        public async Task<bool> ExamStartedAsync(int ExamId, string UserId)
        {
            return await _context.ExamAttampts.AnyAsync(e => e.ExamId == ExamId && e.StudentId == UserId);
        }
    }
}
