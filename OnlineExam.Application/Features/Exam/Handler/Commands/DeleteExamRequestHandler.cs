using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class DeleteExamRequestHandler : IRequestHandler<DeleteExamRequest>
    {
        private readonly IExamRepository _examRepository;
        public DeleteExamRequestHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task Handle(DeleteExamRequest request, CancellationToken cancellationToken)
        {
            var exam = await _examRepository.GetAsync(request.Id);
            if (exam == null)
            {
                throw new BadRequestException($"آزمون با آیدی {exam.Id} یافت نشد.");
            }
            await _examRepository.DeleteAsync(exam);
        }
    }
}
