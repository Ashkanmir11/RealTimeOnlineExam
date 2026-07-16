using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.DTOs.TrueOrFalseQuestionAnswers;
using OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseQuestionAnswers.Handler.Queries
{
    public class GetTrueOrFalseQuestionAnswerRequestHandler : IRequestHandler<GetTrueOrFalseQuestionAnswerRequest, PaginateResponse<GetTrueOrFalseQuestionAnswerDTO>>
    {
        private readonly ITrueOrFalseQuestionAnswersRepository _trueOrFalseQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTrueOrFalseQuestionAnswerRequestHandler(ITrueOrFalseQuestionAnswersRepository trueOrFalseQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _trueOrFalseQuestionAnswersRepository = trueOrFalseQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<PaginateResponse<GetTrueOrFalseQuestionAnswerDTO>> Handle(GetTrueOrFalseQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var answerList = await _trueOrFalseQuestionAnswersRepository.GetAllAsync<GetTrueOrFalseQuestionAnswerDTO>(request.PaginateRequest);
            var temp = new List<GetTrueOrFalseQuestionAnswerDTO>();
            foreach (var answer in answerList.Data)
            {
                temp.Add(new GetTrueOrFalseQuestionAnswerDTO()
                {
                    Id = answer.Id,
                    StudentAnswer = answer.StudentAnswer,
                    User = await _accountRepository.GetUserById(answer.StudentId),
                    TrueOrFalseQuestion = answer.TrueOrFalseQuestion

                });
            }
            answerList.Data = temp;
            return answerList;
        }
    }
}
