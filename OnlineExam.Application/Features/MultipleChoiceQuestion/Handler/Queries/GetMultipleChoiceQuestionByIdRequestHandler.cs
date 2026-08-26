using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Queries
{
    public class GetMultipleChoiceQuestionByIdRequestHandler : IRequestHandler<GetMultipleChoiceQuestionByIdRequest, GetMultipleChoiceQuestionDTO>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public GetMultipleChoiceQuestionByIdRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task<GetMultipleChoiceQuestionDTO> Handle(GetMultipleChoiceQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            return await _multipleChoiceQuestionRepository.GetAsync<GetMultipleChoiceQuestionDTO>(request.Id);
        }
    }
}
