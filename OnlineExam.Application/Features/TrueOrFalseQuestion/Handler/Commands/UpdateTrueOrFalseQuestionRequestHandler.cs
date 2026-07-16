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
namespace OnlineExam.Application.Features.TrueOrFalseQuestion.Handler.Commands
{
    public class UpdateTrueOrFalseQuestionRequestHandler : IRequestHandler<UpdateTrueOrFalseQuestionRequest>
    {
        private readonly ITrueOrFalseQuestionRepository _trueOrFalseQuestionRepository;
        public UpdateTrueOrFalseQuestionRequestHandler(ITrueOrFalseQuestionRepository trueOrFalseQuestionRepository)
        {
            _trueOrFalseQuestionRepository = trueOrFalseQuestionRepository;
        }

        public async Task Handle(UpdateTrueOrFalseQuestionRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrueOfFalseQuestionValidation(_trueOrFalseQuestionRepository);
            var validationResult =await validator.ValidateAsync(request.UpdateTrueOfFalseQuestionDTO);
            if(validationResult.IsValid==false)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
            await _trueOrFalseQuestionRepository.UpdateAsync(request.UpdateTrueOfFalseQuestionDTO.Id, request.UpdateTrueOfFalseQuestionDTO);
        }
    }
}
