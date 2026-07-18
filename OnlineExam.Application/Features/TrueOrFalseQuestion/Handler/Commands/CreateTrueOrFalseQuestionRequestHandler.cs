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
    public class CreateTrueOrFalseQuestionRequestHandler : IRequestHandler<CreateTrueOrFalseQuestionRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public CreateTrueOrFalseQuestionRequestHandler(IExamRepository examRepository, ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _examRepository = examRepository;
            _trueOrFalseQuestionRepository= trueOrFalseQuestionRepository;
        }

        public async Task Handle(CreateTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            await _trueOrFalseQuestionRepository.AddAsync(request.CreateTrueOrFalseQuestionDTO);
        }
    }
}
