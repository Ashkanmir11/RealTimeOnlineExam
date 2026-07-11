using FluentValidation;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.ClassRoom.Validation
{
    public class UpdateClassRoomValidation : AbstractValidator<UpdateClassRoomDTO>
    {
        private readonly IClassRoomRepository _classRoomRepository;

        public UpdateClassRoomValidation(IClassRoomRepository classRoomRepository)
        {
            _classRoomRepository = classRoomRepository;
            RuleFor(e => e.Id).MustAsync(async (Id, Token) =>
            {
                var exist = await _classRoomRepository.ExistAsync(Id);
                return exist;
            });
            RuleFor(e => e.ClassName).NotEmpty().WithMessage("نام کلاس نباید خالی باشد.").MaximumLength(150).WithMessage("نام کلاس نباید بیشتر از 150 کاراکتر باشد.");
        }
    }
}
