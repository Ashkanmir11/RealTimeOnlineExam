using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Commands
{
    public class UpdateQuestionRequestHandler : IRequestHandler<UpdateQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IValidator<UpdateQuestionDTO> _validator;
        public UpdateQuestionRequestHandler(IQuestionRepository questionRepository, IValidator<UpdateQuestionDTO> validator)
        {
            _questionRepository = questionRepository;
            _validator = validator;
        }

        public async Task Handle(UpdateQuestionRequest request, CancellationToken cancellationToken)
        {
            var validitonResult = await _validator.ValidateAsync(request.UpdateQuestionDTO);
            if (validitonResult.IsValid == false)
            {
                var errors = validitonResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            await _questionRepository.DeleteQuestionDetailAsync(request.UpdateQuestionDTO.Id);
            await _questionRepository.UpdateAsync(request.UpdateQuestionDTO.Id, request.UpdateQuestionDTO);
        }
    }
}
