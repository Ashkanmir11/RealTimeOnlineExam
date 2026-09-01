using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class TrueOrFalseAnswersRepository : GenericRepository<TrueOrFalseAnswers>, ITrueOrFalseAnswersRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public TrueOrFalseAnswersRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<TrueOrFalseAnswers> GetByQuestionIdAsync(int questionId)
        {
            return await _context.TrueOrFalseAnswers.Where(e => e.TrueOrFalseQuestionId == questionId).SingleOrDefaultAsync();
        }

        public async Task<GetTrueOrFalseAnswerStudentDTO> GetForStudent(string studentId, int questionId)
        {
            return await _context.TrueOrFalseAnswers.Where(e => e.StudentId == studentId && e.TrueOrFalseQuestionId == questionId)
                            .ProjectTo<GetTrueOrFalseAnswerStudentDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnswerExist(string studentId, int questionId)
        {
            return await _context.TrueOrFalseAnswers.AnyAsync(e => e.StudentId == studentId && e.TrueOrFalseQuestionId == questionId);
        }
    }

}
