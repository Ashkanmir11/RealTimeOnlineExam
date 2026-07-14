using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.MultipleChoiceQuestion.Handler.Queries
{
    public class GetMultipleChoiceQuestionRequestHandler : IRequestHandler<GetMultipleChoiceQuestionRequest, PaginateResponse<GetMultipleChoiceQuestionDTO>>
    {
        private readonly IMultipleChoiceQuestionRepository _multipleChoiceQuestionRepository;
        public GetMultipleChoiceQuestionRequestHandler(IMultipleChoiceQuestionRepository multipleChoiceQuestionRepository)
        {
            _multipleChoiceQuestionRepository = multipleChoiceQuestionRepository;
        }

        public async Task<PaginateResponse<GetMultipleChoiceQuestionDTO>> Handle(GetMultipleChoiceQuestionRequest request, CancellationToken cancellationToken)
        {
            return await _multipleChoiceQuestionRepository.GetAllAsync<GetMultipleChoiceQuestionDTO>(request.paginateRequestDTO);
        }
    }
}
