using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.Response;
namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetQuestionTeacherRequestHandler : IRequestHandler<GetQuestionTeacherRequest, PaginateResponse<GetQuestionTeacherDTO>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionTeacherRequestHandler(IExamRepository examRepository, IAuthServices authServices, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _authServices = authServices;
            _questionRepository = questionRepository;
        }

        public async Task<PaginateResponse<GetQuestionTeacherDTO>> Handle(GetQuestionTeacherRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var isAdmin = await _authServices.IsUserAdminAsync(currentUser);
            bool isTeacher = await _examRepository.IsUserTeacherAsync(currentUser, request.ExamId);
            if (!isTeacher && !isAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این آزمون را ندارید.");
            }
            var result = await _questionRepository.GetByExamIdAsync<GetQuestionTeacherDTO>(request.ExamId, false, "", request.PaginateRequestDTO);

            return result;
        }
    }
}
