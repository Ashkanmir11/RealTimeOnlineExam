using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class MultipleChoiceAnswersRepository : GenericRepository<MultipleChoiceAnswers>, IMultipleChoiceAnswersRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public MultipleChoiceAnswersRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<MultipleChoiceAnswers> GetByQuestionIdAsync(int questionId)
        {
            return await _context.MultipleChoiceAnswers.Where(e => e.MultipleChoiceQuestionId == questionId).SingleOrDefaultAsync();
        }

        public async Task<GetMultipleChoiceAnswerStudentDTO> GetForStudent(string studentId, int questionId)
        {
            return await _context.MultipleChoiceAnswers.Where(e => e.StudentId == studentId && e.MultipleChoiceQuestionId == questionId)
                            .ProjectTo<GetMultipleChoiceAnswerStudentDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<bool> IsAnswerExist(string studentId, int questionId)
        {
            return await _context.MultipleChoiceAnswers.AnyAsync(e => e.StudentId == studentId && e.MultipleChoiceQuestionId == questionId);
        }
    }
}
