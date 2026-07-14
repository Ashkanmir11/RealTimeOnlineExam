using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries;
using OnlineExam.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Queries
{
    public class GetDescriptiveQuestionRequestHandler : IRequestHandler<GetDescriptiveQuestionRequest, PaginateResponse<GetDescriptiveQuestionDTO>>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        public GetDescriptiveQuestionRequestHandler(IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task<PaginateResponse<GetDescriptiveQuestionDTO>> Handle(GetDescriptiveQuestionRequest request, CancellationToken cancellationToken)
        {
            return await _descriptiveQuestionRepository.GetAllAsync<GetDescriptiveQuestionDTO>(request.PaginateRequest);
        }
    }
}
