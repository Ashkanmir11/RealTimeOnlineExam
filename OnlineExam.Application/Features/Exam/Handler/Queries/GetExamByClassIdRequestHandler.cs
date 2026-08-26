using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.Exam.Request.Queries;
using OnlineExam.Application.Response;
namespace OnlineExam.Application.Features.Exam.Handler.Queries
{
    public class GetExamByClassIdRequestHandler : IRequestHandler<GetExamByClassIdRequest, PaginateResponse<GetExamDetailDTO>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        public GetExamByClassIdRequestHandler(IExamRepository examRepository, IAuthServices authServices, IClassRoomRepository classRoomRepository, IClassRoomMembersRepository classRoomMembersRepository)
        {
            _examRepository = examRepository;
            _authServices = authServices;
            _classRoomRepository = classRoomRepository;
            _classRoomMembersRepository = classRoomMembersRepository;
        }


        public async Task<PaginateResponse<GetExamDetailDTO>> Handle(GetExamByClassIdRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isTeacher = await _classRoomRepository.IsUserTeacherAsync(request.ClassId, currentUser);
            bool isStudent = await _classRoomMembersRepository.StudentIsInClassAsync(currentUser, request.ClassId);
            if (!isStudent && !isTeacher)
            {
                throw new AccessForbiddenException("شما دسترسی به این کلاس را ندارید.");
            }
            return await _examRepository.GetByClassIdAsync(request.ClassId, request.PaginateRequestDTO);
        }
    }
}
