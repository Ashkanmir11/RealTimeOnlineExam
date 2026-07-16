using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Handler.Queries
{
    public class GetTrueOrFalseQuestionAnswerByIdRequestHandler : IRequestHandler<GetTrueOrFalseQuestionAnswerByIdRequest, GetTrueOrFalseQuestionAnswerDTO>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTrueOrFalseQuestionAnswerByIdRequestHandler(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetTrueOrFalseQuestionAnswerDTO> Handle(GetTrueOrFalseQuestionAnswerByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _trueOrFalseQuestionAnswersRepository.GetAsync<GetTrueOrFalseQuestionAnswerDTO>(request.Id);
            if (answer == null)
            {
                return null;
            }
            var user = await _accountRepository.GetUserById(answer.StudentId);
            var result = new GetTrueOrFalseQuestionAnswerDTO()
            {
                Id = answer.Id,
                StudentAnswer = answer.StudentAnswer,
                User = user,
                TrueOrFalseQuestion = answer.TrueOrFalseQuestion
            };
            return result;
        }
    }
}
