using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Handler.Queries
{
    public class GetDescriptiveQuestionAnswersByIdRequestHandler : IRequestHandler<GetDescriptiveQuestionAnswersByIdRequest, GetDescriptiveQuestionAnswersDTO>
    {
        private readonly IDescriptiveQuestionAnswersRepository _descriptiveQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetDescriptiveQuestionAnswersByIdRequestHandler(IDescriptiveQuestionAnswersRepository descriptiveQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _descriptiveQuestionAnswersRepository = descriptiveQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<GetDescriptiveQuestionAnswersDTO> Handle(GetDescriptiveQuestionAnswersByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _descriptiveQuestionAnswersRepository.GetAsync<GetDescriptiveQuestionAnswersDTO>(request.Id);
            if(answer==null)
            {
                return null;
            }
            var user =await _accountRepository.GetUserById(answer.StudentId);
            var result = new GetDescriptiveQuestionAnswersDTO()
            {
                Id=answer.Id,
                StudentAnswer = answer.StudentAnswer,
                UserDTO = user,
                DescriptiveQuestion = answer.DescriptiveQuestion

            };
            return result;


        }
    }
}
