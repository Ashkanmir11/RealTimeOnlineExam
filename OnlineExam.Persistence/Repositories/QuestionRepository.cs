using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Helper;
using OnlineExam.Application.Response;
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

        public async Task<PaginateResponse<TResult>> GetByExamIdAsync<TResult>(int examId, bool randomQuestions, string? studentId, PaginateRequestDTO paginateRequestDTO)
        {
            var query = _context.Questions.AsQueryable();

            query = query.Where(e => e.ExamId == examId);
            var totalCount = query.Count();
            var questions = await query.Include(e => e.DescriptiveQuestion).Include(e => e.MultipleChoiceQuestion)
                .Include(e => e.TrueOrFalseQuestion).ProjectTo<TResult>(_mapper.ConfigurationProvider).ToListAsync();

            if (randomQuestions)
            {
                questions = questions.OrderBy(q => HashCode.Combine(studentId, q.GetType().GetProperty("Id").GetValue(q))).ToList();
            }
            var skip = PaginateHelper<TResult>.GetSkip(paginateRequestDTO);
            questions = questions.Skip(skip).Take(paginateRequestDTO.PageCount).ToList();
            var result = PaginateHelper<TResult>.Paginate(questions, totalCount, paginateRequestDTO);
            return result;

        }

        public async Task<Question> GetByQuestionDetailIdAsync(bool trueOrFalse, bool multipleChoice, bool descriptive, int id)
        {
            int questionDetailId;
            if (trueOrFalse)
            {
                questionDetailId = await _context.TrueOrFalseAnswers.Where(e=>e.Id == id).Select(e=>e.TrueOrFalseQuestionId).FirstOrDefaultAsync();
                return await _context.Questions.Where(e => e.TrueOrFalseQuestionId == questionDetailId).FirstOrDefaultAsync();
            }
            if (multipleChoice)
            {
                questionDetailId = await _context.MultipleChoiceAnswers.Where(e => e.Id == id).Select(e => e.MultipleChoiceQuestionId).FirstOrDefaultAsync();
                return await _context.Questions.Where(e => e.MultipleChoiceQuestionId == questionDetailId).FirstOrDefaultAsync();
            }
            questionDetailId =await _context.DescriptiveAnswers.Where(e => e.Id == id).Select(e => e.DescriptiveQuestionId).FirstOrDefaultAsync();
            return await _context.Questions.Where(e => e.DescriptiveQuestionId == questionDetailId).FirstOrDefaultAsync();

        }

        public async Task RemoveNoRelationQuestionDetail()
        {
            try
            {
                var unusedTrueOrFalseQuestions = await _context.TrueOrFalseQuestions.Where(tf => !_context.Questions.Any(q => q.TrueOrFalseQuestionId == tf.Id)).ToListAsync();
                _context.TrueOrFalseQuestions.RemoveRange(unusedTrueOrFalseQuestions);

                var unusedDescriptiveQuestions = await _context.DescriptiveQuestions.Where(tf => !_context.Questions.Any(q => q.DescriptiveQuestionId == tf.Id)).ToListAsync();
                _context.DescriptiveQuestions.RemoveRange(unusedDescriptiveQuestions);

                var unusedMultipleChoiceQuestions = await _context.MultipleChoiceQuestions.Where(tf => !_context.Questions.Any(q => q.MultipleChoiceQuestionId == tf.Id)).ToListAsync();
                _context.MultipleChoiceQuestions.RemoveRange(unusedMultipleChoiceQuestions);



                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
