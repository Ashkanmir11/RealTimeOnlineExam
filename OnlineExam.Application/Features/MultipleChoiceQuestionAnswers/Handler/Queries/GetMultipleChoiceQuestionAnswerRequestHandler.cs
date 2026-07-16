using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Handler.Queries
{
    public class GetMultipleChoiceQuestionAnswerRequestHandler : IRequestHandler<GetMultipleChoiceQuestionAnswerRequest, PaginateResponse<GetMultipleChoiceQuestionAnswerDTO>>
    {
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetMultipleChoiceQuestionAnswerRequestHandler(IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<PaginateResponse<GetMultipleChoiceQuestionAnswerDTO>> Handle(GetMultipleChoiceQuestionAnswerRequest request, CancellationToken cancellationToken)
        {
            var answerList = await _multipleChoiceQuestionAnswersRepository.GetAllAsync<GetMultipleChoiceQuestionAnswerDTO>(request.PaginateRequest);
            var temp = new List<GetMultipleChoiceQuestionAnswerDTO>();
            foreach (var answer in answerList.Data)
            {
                temp.Add(new GetMultipleChoiceQuestionAnswerDTO()
                {
                    Id = answer.Id,
                    StudentChoice = answer.StudentChoice,
                    User = await _accountRepository.GetUserById(answer.StudentId),
                    MultipleChoiceQuestion = answer.MultipleChoiceQuestion

                });
            }
            answerList.Data = temp;
            return answerList;
        }
    }
}
