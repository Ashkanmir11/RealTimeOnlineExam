using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.LogType.Validation
{
    public class UpdateLogTypeValidation : AbstractValidator<UpdateLogTypeDTO>
    {

        public UpdateLogTypeValidation()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("نام نوع لاگ نباید خالی باشد.")
                .MaximumLength(100).WithMessage("نام نوع لاگ نباید بیشتر از 100 کاراکتر باشد");

        }
    }
}
