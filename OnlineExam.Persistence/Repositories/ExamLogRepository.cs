using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ExamLog;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class ExamLogRepository : GenericRepository<ExamLog>, IExamLogRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ExamLogRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GetExamLogDTO>> GetForTeacher(string studentId,int examId)
        {
            return await _context.ExamsLogs.Where(e => e.StudentId == studentId && e.ExamId==examId).ProjectTo<GetExamLogDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
