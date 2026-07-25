using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Persistence.Repositories
{
    public class DescriptiveAnswersRepository : GenericRepository<DescriptiveAnswers>, IDescriptiveAnswersRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public DescriptiveAnswersRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<DescriptiveAnswers> GetByQuestionIdAsync(int questionId)
        {
            return await _context.DescriptiveAnswers.Where(e => e.DescriptiveQuestionId == questionId).SingleOrDefaultAsync();
        }

        public async Task<GetDescriptiveAnswerStudentDTO> GetForStudent(string studentId ,int questionId)
        {
            return await _context.DescriptiveAnswers.Where(e => e.StudentId == studentId && e.DescriptiveQuestionId == questionId)
                .ProjectTo<GetDescriptiveAnswerStudentDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
