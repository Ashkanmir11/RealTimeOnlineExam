using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam.Validation;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class UpdateExamRequestHandler : IRequestHandler<UpdateExamRequest>
    {
        private readonly IExamRepository _examRepository;
        public UpdateExamRequestHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public async Task Handle(UpdateExamRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateExamValidation(_examRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateExamDTO);
            if(validationResult.IsValid==false)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _examRepository.UpdateAsync(request.UpdateExamDTO.Id, request.UpdateExamDTO);
        }
    }
}
