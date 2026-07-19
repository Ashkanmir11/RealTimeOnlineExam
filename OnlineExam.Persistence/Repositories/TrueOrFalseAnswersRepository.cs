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
    }

}
