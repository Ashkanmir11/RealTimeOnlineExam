using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class LogTypeRepository : GenericRepository<LogType>, ILogTypeRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public LogTypeRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
    }
}
