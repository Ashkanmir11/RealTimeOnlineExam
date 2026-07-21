using AutoMapper;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.Response;
using OpenAI.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetQuestionWithAnswerRequestHandler : IRequestHandler<GetQuestionWithAnswerRequest, PaginateResponse<GetQuestionTeacherDTO>>
    {
        private readonly IQuestionRepository _quesitonRepository;
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IMapper _mapper;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        public GetQuestionWithAnswerRequestHandler(IQuestionRepository quesitonRepository, IExamRepository examRepository
            , IAuthServices authServices, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository, IMapper mapper
            , IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository, IDescriptiveAnswersRepository descriptiveAnswersRepository)
        {
            _quesitonRepository = quesitonRepository;
            _examRepository = examRepository;
            _authServices = authServices;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _mapper = mapper;
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
        }

        public async Task<PaginateResponse<GetQuestionTeacherDTO>> Handle(GetQuestionWithAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var access = await _examRepository.IsUserTeacherAsync(currentUser, request.ExamId);
            if (access == false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به سوالات و پاسخ های این آزمون ندارید.");
            }

            var questions = await _quesitonRepository.GetByExamIdAsync<GetQuestionTeacherDTO>(request.ExamId, false, request.StudentId, request.PaginateRequestDTO);
            if (questions == null)
            {
                return null;

            }
            foreach (var question in questions.Data)
            {
                if (question.TrueOrFalseQuestion != null)
                {
                    var answer =await _trueOrFalseAnswersRepository.GetByQuestionIdAsync(question.TrueOrFalseQuestion.Id);
                    var answerDto = _mapper.Map<GetTrueOrFalseAnswerTeacherDTO>(answer);
                    question.TrueOrFalseQuestion.Answer = answerDto;
                }
                else if (question.MultipleChoiceQuestion != null)
                {
                    var answer = await _multipleChoiceAnswersRepository.GetByQuestionIdAsync(question.MultipleChoiceQuestion.Id);
                    var answerDto = _mapper.Map<GetMultipleChoiceAnswerTeacherDTO>(answer);
                    question.MultipleChoiceQuestion.Answer = answerDto;
                }
                else if (question.DescriptiveQuestion != null)
                {
                    var answer = await _descriptiveAnswersRepository.GetByQuestionIdAsync(question.DescriptiveQuestion.Id);
                    var answerDto = _mapper.Map<GetDescriptiveAnswersTeacherDTO>(answer);
                    question.DescriptiveQuestion.Answer = answerDto;

                }
            }

            return questions;
        }
    }
}
