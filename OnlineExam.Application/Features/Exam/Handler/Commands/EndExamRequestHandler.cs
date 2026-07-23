using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Responses;
using OnlineExam.Application.Contracts.Identity;
using OpenAI.Realtime;
using OnlineExam.Application.Contracts.AIServices;
using OnlineExam.Application.DTOs.Question;
namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class EndExamRequestHandler : IRequestHandler<EndExamRequest>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAuthServices _authServices;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        private readonly IAiServices _aiServices;
        private readonly IExamAttamptRepository _examAttamptRepository;
        public EndExamRequestHandler(IAccountRepository accountRepository
            , IQuestionRepository questionRepository, IAuthServices authServices, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository
            , IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository, IDescriptiveAnswersRepository descriptiveAnswersRepository
            , IAiServices aiServices, IExamAttamptRepository examAttamptRepository)
        {
            _accountRepository = accountRepository;
            _questionRepository = questionRepository;
            _authServices = authServices;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
            _aiServices = aiServices;
            _examAttamptRepository = examAttamptRepository;
        }
        public async Task Handle(EndExamRequest request, CancellationToken cancellationToken)
        {
            var currentUserId = await _authServices.GetCurrentUserIdAsync();
            var user = await _accountRepository.GetUserByIdAsync(currentUserId);
            await _examAttamptRepository.EndExamAsync(request.ExamId, currentUserId);

            var questionList = await _questionRepository.GetByExamIdAsync<GetQuestionTeacherDTO>(request.ExamId, false, currentUserId, new DTOs.Common.PaginateRequestDTO() { PageCount = 9999, PageNumber = 1 });
            
            //Automatic Grading
            foreach (var question in questionList.Data)
            {
                if (question.TrueOrFalseQuestion != null)
                {
                    var answer = await _trueOrFalseAnswersRepository.GetByQuestionIdAsync(question.TrueOrFalseQuestion.Id);
                    if (answer.StudentAnswer == question.TrueOrFalseQuestion.CorrectAnswer)
                    {
                        answer.StudentScore = question.TotalScore;
                    }
                    await _trueOrFalseAnswersRepository.UpdateAsync(answer.Id, answer);
                }
                if (question.MultipleChoiceQuestion != null)
                {
                    var answer = await _multipleChoiceAnswersRepository.GetByQuestionIdAsync(question.MultipleChoiceQuestion.Id);
                    if (answer.StudentChoice == question.MultipleChoiceQuestion.CorrectChoice)
                    {
                        answer.StudentScore = question.TotalScore;
                    }
                    await _multipleChoiceAnswersRepository.UpdateAsync(answer.Id, answer);
                }
                else if(question.DescriptiveQuestion != null) 
                {
                    var answer = await _descriptiveAnswersRepository.GetByQuestionIdAsync(question.DescriptiveQuestion.Id);
                    var score =await _aiServices.GetScoreAsync(answer.StudentAnswer, question.DescriptiveQuestion.CorrectAnswer, question.TotalScore);
                    answer.StudentScore = score;
                    await _descriptiveAnswersRepository.UpdateAsync(answer.Id, answer);
                }
            }

        }
    }
}
