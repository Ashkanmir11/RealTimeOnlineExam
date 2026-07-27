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

        public UpdateClassRoomValidation(IClassRoomRepository classRoomRepository)
        {
            RuleFor(e => e.ClassName).NotEmpty().WithMessage("نام کلاس نباید خالی باشد.").MaximumLength(150).WithMessage("نام کلاس نباید بیشتر از 150 کاراکتر باشد.");
        }
    }
}
