using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Handler.Queries
{
    public class GetDescriptiveQuestionAnswersRequestHandler : IRequestHandler<GetDescriptiveQuestionAnswersRequest, PaginateResponse<GetDescriptiveQuestionAnswersDTO>>
    {
        private readonly IDescriptiveQuestionAnswersRepository _descriptiveQuestionAnswersRepository;
        private readonly IAccountRepository _accountRepository;

        public GetDescriptiveQuestionAnswersRequestHandler(IDescriptiveQuestionAnswersRepository descriptiveQuestionAnswersRepository, IAccountRepository accountRepository)
        {
            _descriptiveQuestionAnswersRepository = descriptiveQuestionAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<PaginateResponse<GetDescriptiveQuestionAnswersDTO>> Handle(GetDescriptiveQuestionAnswersRequest request, CancellationToken cancellationToken)
        {
            var answerList=await _descriptiveQuestionAnswersRepository.GetAllAsync<GetDescriptiveQuestionAnswersDTO>(request.PaginateRequest);
            var temp = new List<GetDescriptiveQuestionAnswersDTO>();
            foreach(var answer in answerList.Data)
            {
                temp.Add(new GetDescriptiveQuestionAnswersDTO()
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
