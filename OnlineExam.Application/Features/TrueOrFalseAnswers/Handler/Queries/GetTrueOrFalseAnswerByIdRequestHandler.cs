using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Queries
{
    public class GetTrueOrFalseAnswerByIdRequestHandler : IRequestHandler<GetTrueOrFalseAnswerByIdRequest, GetTrueOrFalseAnswerDTO>
    {
        private readonly ITrueOrFalseAnswersRepository _TrueOrFalseAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetTrueOrFalseAnswerByIdRequestHandler(ITrueOrFalseAnswersRepository TrueOrFalseAnswersRepository, IAccountRepository accountRepository)
        {
            _TrueOrFalseAnswersRepository = TrueOrFalseAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetTrueOrFalseAnswerDTO> Handle(GetTrueOrFalseAnswerByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _TrueOrFalseAnswersRepository.GetAsync<GetTrueOrFalseAnswerDTO>(request.Id);
            if (answer == null)
            {
                return null;
            }
            var user = await _accountRepository.GetUserByIdAsync(answer.StudentId);
            var result = new GetTrueOrFalseAnswerDTO()
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
