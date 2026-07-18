using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ExamAttampt.Request.Commands;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.ExamAttampt.Handler.Commands
{
    public class CreateExamAttamptRequestHandler : IRequestHandler<CreateExamAttamptRequest>
    {
        private readonly IExamAttamptRepository _examAttamptRepository;
        public CreateExamAttamptRequestHandler(IExamAttamptRepository examAttamptRepository)
        {
            _examAttamptRepository = examAttamptRepository;
        }
        public async Task Handle(CreateExamAttamptRequest request, CancellationToken cancellationToken)
        {
            var examAttampt = new Domain.Entities.ExamAttampt()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(request.ExamMinute),
                ExamId = request.ExamId,
                IsEnded = false,
                StudentId = request.UserId
            };
            await _examAttamptRepository.AddAsync(examAttampt);
        }
    }
}
