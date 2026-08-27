using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Features.Exam.Request.Queries;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.Exam.Handler.Queries
{
    public class GetExamByIdRequestHandler : IRequestHandler<GetExamByIdRequest, GetExamDTO>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        public GetExamByIdRequestHandler(IExamRepository examRepository,IAuthServices authServices)
        {
            _examRepository = examRepository;
            _authServices = authServices;
        }
        public async Task<GetExamDTO> Handle(GetExamByIdRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isUserTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.Id);
            if(!isUserTeacher)
            {
                throw new AccessForbiddenException("شما دسترسی به این آزمون را ندارید.");
            }
            return await _examRepository.GetAsync<GetExamDTO>(request.Id);
        }
    }
}
