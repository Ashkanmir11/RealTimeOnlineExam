using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Identity.Validation
{
    public class LoginDtoValidaiton : AbstractValidator<LoginDTO>
    {
        public LoginDtoValidaiton()
        {
            RuleFor(e => e.Email).NotEmpty().WithMessage("ایمیل نباید خالی باشد.").EmailAddress().WithMessage("ایمیل معتبر نیست.");
            RuleFor(e => e.Password).NotEmpty().WithMessage("رمز نباید خالی باشد.");

        }
    }
}
