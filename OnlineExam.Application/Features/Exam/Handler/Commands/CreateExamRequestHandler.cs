using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Features.Exam.Request.Commands;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.DTOs.Exam.Validation;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Helper;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class CreateExamRequestHandler : IRequestHandler<CreateExamRequest>
    {
        private readonly IClassRoomRepository _classRepository;
        private readonly IExamRepository _examRepository;
        public CreateExamRequestHandler(IClassRoomRepository classRepository, IExamRepository examRepository)
        {
            _classRepository = classRepository;
            _examRepository = examRepository;
        }

        public async Task Handle(CreateExamRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateExamValidation(_classRepository);
            var validationResult = await validator.ValidateAsync(request.CreateExamDTO);
            if (validationResult.IsValid == false)
            {
                throw new ValidationException(ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList()));
            }
            await _examRepository.AddAsync<CreateExamDTO>(request.CreateExamDTO);
        }
    }
}
