using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveQuestion.Handler.Queries
{
    public class GetDescriptiveQuestionByIdReqeustHandler : IRequestHandler<GetDescriptiveQuestionByIdRequest, GetDescriptiveQuestionDTO>
    {
        private readonly IDescriptiveQuestionRepository _descriptiveQuestionRepository;
        public GetDescriptiveQuestionByIdReqeustHandler(IDescriptiveQuestionRepository descriptiveQuestionRepository)
        {
            _descriptiveQuestionRepository = descriptiveQuestionRepository;
        }

        public async Task<GetDescriptiveQuestionDTO> Handle(GetDescriptiveQuestionByIdRequest request, CancellationToken cancellationToken)
        {
            return await _descriptiveQuestionRepository.GetAsync<GetDescriptiveQuestionDTO>(request.Id);
        }
    }
}
