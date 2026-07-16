using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Queries
{
    public class GetDescriptiveAnswersByIdRequestHandler : IRequestHandler<GetDescriptiveAnswersByIdRequest, GetDescriptiveAnswersDTO>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetDescriptiveAnswersByIdRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository, IAccountRepository accountRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<GetDescriptiveAnswersDTO> Handle(GetDescriptiveAnswersByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _DescriptiveAnswersRepository.GetAsync<GetDescriptiveAnswersDTO>(request.Id);
            if(answer==null)
            {
                return null;
            }
            var user =await _accountRepository.GetUserById(answer.StudentId);
            var result = new GetDescriptiveAnswersDTO()
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
