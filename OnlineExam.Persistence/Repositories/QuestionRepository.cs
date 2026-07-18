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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private readonly OnlineExamDbContext _context;
        private readonly IMapper _mapper;
        public QuestionRepository(OnlineExamDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteQuestionDetailAsync(int questionId)
        {
            var question = await _context.Questions.Where(e => e.Id == questionId).Include(e => e.TrueOrFalseQuestion)
                .Include(e => e.DescriptiveQuestion).Include(e => e.MultipleChoiceQuestion).SingleOrDefaultAsync();
            if (question.TrueOrFalseQuestion != null)
            {
                var questionDetail = await _context.TrueOrFalseQuestions.FindAsync(question.TrueOrFalseQuestionId);
                _context.TrueOrFalseQuestions.Remove(questionDetail);
            }
            if (question.MultipleChoiceQuestion != null)
            {
                var questionDetail = await _context.MultipleChoiceQuestions.FindAsync(question.MultipleChoiceQuestionId);
                _context.MultipleChoiceQuestions.Remove(questionDetail);
            }
            if (question.DescriptiveQuestion != null)
            {
                var questionDetail = await _context.DescriptiveQuestions.FindAsync(question.DescriptiveQuestionId);
                _context.DescriptiveQuestions.Remove(questionDetail);
            }
        }
    }
}
