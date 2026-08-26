using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Queries;
using OnlineExam.Application.Response;

namespace OnlineExam.Application.Features.Exam.Handler.Queries
{
    public class GetExamRequestHandler : IRequestHandler<GetExamRequest, PaginateResponse<GetExamDTO>>
    {
        private readonly IExamRepository _examRepository;
        public GetExamRequestHandler(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public Task<PaginateResponse<GetExamDTO>> Handle(GetExamRequest request, CancellationToken cancellationToken)
        {
            return _examRepository.GetAllAsync<GetExamDTO>(request.PaginateRequestDTO);
        }
    }
}
