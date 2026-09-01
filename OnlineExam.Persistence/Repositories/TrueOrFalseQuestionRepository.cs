using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class TrueOrFalseQuestionRepository : GenericRepository<TrueOrFalseQuestion>, ITrueOrFalseQuestionRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public TrueOrFalseQuestionRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
    }
}
