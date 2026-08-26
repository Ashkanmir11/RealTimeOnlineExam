using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Queries
{
    public class GetMultipleChoiceAnswerRequestHandler : IRequestHandler<GetMultipleChoiceAnswerRequest, PaginateResponse<GetMultipleChoiceAnswerDTO>>
    {
        private readonly IMultipleChoiceAnswersRepository _MultipleChoiceAnswersRepository;
        private readonly IAccountRepository _accountRepository;
        public GetMultipleChoiceAnswerRequestHandler(IMultipleChoiceAnswersRepository MultipleChoiceAnswersRepository, IAccountRepository accountRepository)
        {
            _MultipleChoiceAnswersRepository = MultipleChoiceAnswersRepository;
            _accountRepository = accountRepository;
        }

        public async Task<PaginateResponse<GetMultipleChoiceAnswerDTO>> Handle(GetMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var answerList = await _MultipleChoiceAnswersRepository.GetAllAsync<GetMultipleChoiceAnswerDTO>(request.PaginateRequest);
            var temp = new List<GetMultipleChoiceAnswerDTO>();
            foreach (var answer in answerList.Data)
            {
                temp.Add(new GetMultipleChoiceAnswerDTO()
                {
                    Id = answer.Id,
                    StudentChoice = answer.StudentChoice,
                    User = await _accountRepository.GetUserByIdAsync(answer.StudentId),
                    MultipleChoiceQuestion = answer.MultipleChoiceQuestion

                });
            }
            answerList.Data = temp;
            return answerList;
        }
    }
}
