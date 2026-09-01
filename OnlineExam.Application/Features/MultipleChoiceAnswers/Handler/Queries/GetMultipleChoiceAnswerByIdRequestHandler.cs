using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Queries
{
    public class GetMultipleChoiceAnswerByIdRequestHandler : IRequestHandler<GetMultipleChoiceAnswerByIdRequest, GetMultipleChoiceAnswerDTO>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetMultipleChoiceAnswerByIdRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IAccountRepository accountRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetMultipleChoiceAnswerDTO> Handle(GetMultipleChoiceAnswerByIdRequest request, CancellationToken cancellationToken)
        {
            var answer = await _MultipleChoiceAnswersRepository.GetAsync<GetMultipleChoiceAnswerDTO>(request.Id);
            if (answer == null)
            {
                return null;
            }
            var user = await _accountRepository.GetUserByIdAsync(answer.StudentId);
            var result = new GetMultipleChoiceAnswerDTO()
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
