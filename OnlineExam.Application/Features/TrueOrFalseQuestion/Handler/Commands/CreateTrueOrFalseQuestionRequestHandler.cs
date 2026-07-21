using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion.Validation;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using FluentValidation;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;

namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Commands
{
    public class CreateTrueOrFalseQuestionRequestHandler : IRequestHandler<CreateTrueOrFalseQuestionRequest, int>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public CreateTrueOrFalseQuestionRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }

        public async Task<int> Handle(CreateTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            var result = await _trueOrFalseQuestionRepository.AddAsync(request.CreateTrueOrFalseQuestionDTO);
            return result.Id;
        }
    }
}
