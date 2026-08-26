using MediatR;
using OnlineExam.Application.Contracts.AIServices;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class EndTimeoutExamsRequestHandler : IRequestHandler<EndTimeoutExamsRequest>
    {
        private readonly IExamAttamptRepository _examAttamptRepository;
        private readonly IMediator _mediator;
        public EndTimeoutExamsRequestHandler(IExamAttamptRepository examAttamptRepository, IMediator mediator)
        {
            _examAttamptRepository = examAttamptRepository;
            _mediator = mediator;
        }

        public async Task Handle(EndTimeoutExamsRequest request, CancellationToken cancellationToken)
        {
            var timeoutAttampt = await _examAttamptRepository.GetTimeoutExamAttampt();
            foreach (var attampts in timeoutAttampt)
            {
                await _mediator.Send(new EndExamRequest() { ExamId = attampts.ExamId, StudentId = attampts.StudentId });
            }
        }
    }
}
