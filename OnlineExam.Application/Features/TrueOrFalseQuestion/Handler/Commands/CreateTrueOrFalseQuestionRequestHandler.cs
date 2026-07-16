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
        private readonly IValidator<CreateTrueOrFalseQuestionDTO> _validator;
        public CreateTrueOrFalseQuestionRequestHandler(IExamRepository examRepository, ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository
            , IValidator<CreateTrueOrFalseQuestionDTO> validator)
        {
            _examRepository = examRepository;
            _trueOrFalseQuestionRepository= trueOrFalseQuestionRepository;
            _validator = validator;
        }

        public async Task Handle(CreateTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CreateTrueOrFalseQuestionDTO);
            if(validationResult.IsValid==false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            await _trueOrFalseQuestionRepository.AddAsync(request.CreateTrueOrFalseQuestionDTO);

        }
    }
}
