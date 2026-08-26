//using FluentValidation;
using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
namespace OnlineExam.Application.Features.ClassRoom.Handler.Command
{
    public class UpdateClassRoomRequestHandler : IRequestHandler<UpdateClassRoomRequest>
    {
        private readonly IValidator<UpdateClassRoomDTO> _validator;
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IAuthServices _authServices;
        public UpdateClassRoomRequestHandler(IClassRoomRepository classRoomRepository, IAuthServices authServices, IValidator<UpdateClassRoomDTO> validator)
        {
            _classRoomRepository = classRoomRepository;
            _authServices = authServices;
            _validator = validator;
        }

        public async Task Handle(UpdateClassRoomRequest request, CancellationToken cancellationToken)
        {
            var classRoom = await _classRoomRepository.GetAsync(request.Id);
            if (classRoom == null)
            {
                throw new NotFoundException($"آیدی {request.Id} یافت نشد.");
            }

            var currentUser = await _authServices.GetCurrentUserIdAsync();
            bool isUserAdmin = await _authServices.IsUserAdminAsync(currentUser);
            if (classRoom.TeacherId != currentUser && !isUserAdmin)
            {
                throw new AccessForbiddenException("شما دسترسی به این عملیات را ندارید.");
            }
            var validationResult = await _validator.ValidateAsync(request.UpdateClassRoomDTO);
            if (validationResult.IsValid == false)
            {
                throw new Application.Exceptions.ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }
            await _classRoomRepository.UpdateAsync(request.Id, request.UpdateClassRoomDTO);
        }
    }
}
