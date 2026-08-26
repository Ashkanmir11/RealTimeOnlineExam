using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Queries
{
    public class GetTrueOrFalseAnswerRequestHandler : IRequestHandler<GetTrueOrFalseAnswerRequest, PaginateResponse<GetTrueOrFalseAnswerDTO>>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTrueOrFalseAnswerRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository, IAccountRepository accountRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _accountRepository = accountRepository;
        }
        public async Task<PaginateResponse<GetTrueOrFalseAnswerDTO>> Handle(GetTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var answerList = await _TrueOrFalseAnswersRepository.GetAllAsync<GetTrueOrFalseAnswerDTO>(request.PaginateRequest);
            var temp = new List<GetTrueOrFalseAnswerDTO>();
            foreach (var answer in answerList.Data)
            {
                temp.Add(new GetTrueOrFalseAnswerDTO()
                {
                    Id = answer.Id,
                    StudentAnswer = answer.StudentAnswer,
                    User = await _accountRepository.GetUserByIdAsync(answer.StudentId),
                    TrueOrFalseQuestion = answer.TrueOrFalseQuestion

                });
            }
            answerList.Data = temp;
            return answerList;
        }
    }
}
