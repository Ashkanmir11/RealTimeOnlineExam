using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class DescriptiveQuestionRepository : GenericRepository<DescriptiveQuestion>, IDescriptiveQuestionRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public DescriptiveQuestionRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
    }
}
