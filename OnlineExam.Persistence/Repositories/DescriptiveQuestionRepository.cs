using AutoMapper;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class DescriptiveQuestionRepository:GenericRepository<DescriptiveQuestion>, IDescriptiveQuestionRepository
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
