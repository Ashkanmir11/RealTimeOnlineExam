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
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public ExamRepository(OnlineExamDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<int> GetCurrentQuestionNumber(int examId)
        {
            var exam = await _context.Exams.Where(e => e.Id == examId).SingleOrDefaultAsync();
            int multipleQuestionMax =await _context.MultipleChoiceQuestions.AnyAsync()? await _context.MultipleChoiceQuestions.Where(e => e.ExamId == examId).Select(e => e.QuestionNumber).MaxAsync():0;
            int descpritiveQuestionMax = await _context.DescriptiveQuestions.AnyAsync() ? await _context.DescriptiveQuestions.Where(e => e.ExamId == examId).Select(e => e.QuestionNumber).MaxAsync():0;
            int trueOrFalseQuestionMax = await _context.TrueOrFalseQuestions.AnyAsync() ? await _context.TrueOrFalseQuestions.Where(e=>e.ExamId==examId).Select(e => e.QuestionNumber).MaxAsync():0;

            int max= Math.Max(multipleQuestionMax, Math.Max(descpritiveQuestionMax, trueOrFalseQuestionMax));
            return max + 1;
        }
    }
}
