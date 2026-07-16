using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Queries
{
    public class GetDescriptiveAnswersRequestHandler : IRequestHandler<GetDescriptiveAnswersRequest, PaginateResponse<GetDescriptiveAnswersDTO>>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        private readonly IAccountRepository _accountRepository;

        public GetDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository, IAccountRepository accountRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<PaginateResponse<GetDescriptiveAnswersDTO>> Handle(GetDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var answerList=await _DescriptiveAnswersRepository.GetAllAsync<GetDescriptiveAnswersDTO>(request.PaginateRequest);
            var temp = new List<GetDescriptiveAnswersDTO>();
            foreach(var answer in answerList.Data)
            {
                temp.Add(new GetDescriptiveAnswersDTO()
                {
                    Id = answer.Id,
                    StudentAnswer = answer.StudentAnswer,
                    UserDTO = await _accountRepository.GetUserById(answer.StudentId),
                    DescriptiveQuestion = answer.DescriptiveQuestion

                });
            }
            answerList.Data= temp;
            return answerList;

        }
    }
}
