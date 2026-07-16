using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.DTOs.MultipleChoiceQuestionAnswers;
using OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestionAnswers.Handler.Queries
{
    public class GetMultipleChoiceQuestionAnswerByIdRequestHandler : IRequestHandler<GetMultipleChoiceQuestionAnswerByIdRequest, GetMultipleChoiceQuestionAnswerDTO>
    {
        private readonly IMultipleChoiceQuestionAnswersRepository _multipleChoiceQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetMultipleChoiceQuestionAnswerByIdRequestHandler(IMultipleChoiceQuestionAnswersRepository multipleChoiceQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _multipleChoiceQuestionAnswersRepository = multipleChoiceQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetMultipleChoiceQuestionAnswerDTO> Handle(GetMultipleChoiceQuestionAnswerByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _multipleChoiceQuestionAnswersRepository.GetAsync<GetMultipleChoiceQuestionAnswerDTO>(request.Id);
            if (answer == null)
            {
                return null;
            }
            var user = await _accountRepository.GetUserById(answer.StudentId);
            var result = new GetMultipleChoiceQuestionAnswerDTO()
            {
                Id = answer.Id,
                StudentChoice = answer.StudentChoice,
                User = user,
                MultipleChoiceQuestion = answer.MultipleChoiceQuestion

            };
            return result;
        }
    }
}
