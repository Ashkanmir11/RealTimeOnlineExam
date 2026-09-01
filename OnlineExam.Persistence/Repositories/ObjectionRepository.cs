using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Persistence.Repositories
{
    public class ObjectionRepository : GenericRepository<Objection>, IObjectionRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ObjectionRepository(OnlineExamDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
