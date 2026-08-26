using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoom.Request.Command;

namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class DeleteClassRoomRequstHandler : IRequestHandler<DeleteClassRoomRequest, Unit>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        private readonly IQuestionRepository _questionRepository;
        public DeleteClassRoomRequstHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices, IQuestionRepository questionRepository)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
            _questionRepository = questionRepository;
        }

        public async Task<Unit> Handle(DeleteClassRoomRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var classRoom = await _classRoomRepository.GetAsync(request.Id);
            if (classRoom == null)
            {
                throw new NotFoundException("کلاس پیدا نشد.");
            }
            bool isUserAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (classRoom.TeacherId != currentUser && !isUserAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }



            if (classRoom == null)
            {
                throw new NotFoundException($"آیدی {request.Id} یافت نشد.");
            }
            await _classRoomRepository.DeleteAsync(classRoom);
            await _questionRepository.RemoveNoRelationQuestionDetail();
            return Unit.Value;
        }


    }
}
