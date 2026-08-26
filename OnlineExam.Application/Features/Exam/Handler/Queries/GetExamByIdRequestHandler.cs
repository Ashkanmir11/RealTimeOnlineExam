using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Queries;

namespace OnlineExam.Application.Features.Exam.Handler.Queries
{
    public class GetExamByIdRequestHandler : IRequestHandler<GetExamByIdRequest, GetExamDTO>
    {
        private readonly IExamRepository _examRepository;
        public GetExamByIdRequestHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }
        public async Task<GetExamDTO> Handle(GetExamByIdRequest request, CancellationToken cancellationToken)
        {
            return await _examRepository.GetAsync<GetExamDTO>(request.Id);

        }
    }
}
