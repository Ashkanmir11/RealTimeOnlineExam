using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Domain.Entities;
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

        public async Task EndExamAsync(int examId, string userId)
        {
            var examAttampt = await _context.ExamAttampts.Where(e => e.ExamId == examId && e.StudentId == userId).SingleOrDefaultAsync();
            if (examAttampt == null)
            {
                throw new BadRequestException("کاربر به آزمون وارد نشده.");
            }
            examAttampt.IsEnded = true;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExamEndedAsync(int examId, string userId)
        {
            var examAttampt = await _context.ExamAttampts.Where(e => e.ExamId == examId && e.StudentId == userId).SingleOrDefaultAsync();
            if (examAttampt == null)
            {
                throw new BadRequestException("آزمون شروع نشده.");
            }
            if (DateTime.Now > examAttampt.EndDate)
            {
                examAttampt.IsEnded = true;
                await _context.SaveChangesAsync();
            }

            return await _context.ExamAttampts.Where(e => e.ExamId == examId && e.StudentId == userId).Select(e => e.IsEnded).SingleOrDefaultAsync();
        }

        public async Task<bool> ExamStartedAsync(int examId, string userId)
        {
            return await _context.ExamAttampts.AnyAsync(e => e.ExamId == examId && e.StudentId == userId);
        }

        public async Task<double> GetRemainingSeconds(int examId, string studentId)
        {
            var endTime = await _context.ExamAttampts.Where(e => e.ExamId == examId && e.StudentId == studentId).Select(e => e.EndDate).FirstOrDefaultAsync();
            return endTime.Subtract(DateTime.Now).TotalSeconds;

        }
    }
}
