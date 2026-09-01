using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceAnswers;
using OnlineExam.Application.Features.MultipleChoiceAnswers.Request.Queries;

namespace OnlineExam.Application.Features.MultipleChoiceAnswers.Handler.Queries
{
    public class GetMyMultipleChoiceAnswerRequestHandler : IRequestHandler<GetMyMultipleChoiceAnswerRequest, GetMultipleChoiceAnswerStudentDTO>
    {
        private readonly IAuthServices _authServices;
        private readonly IMultipleChoiceAnswersRepository _multipleChoiceAnswersRepository;
        public GetMyMultipleChoiceAnswerRequestHandler(IAuthServices authServices, IMultipleChoiceAnswersRepository multipleChoiceAnswersRepository)
        {
            _authServices = authServices;
            _multipleChoiceAnswersRepository = multipleChoiceAnswersRepository;
        }

        public async Task<GetMultipleChoiceAnswerStudentDTO> Handle(GetMyMultipleChoiceAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            return await _multipleChoiceAnswersRepository.GetForStudent(currentUser, request.MultipleChoiceQuestionId);
        }
    }
}
