using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.DTOs.Objection.Validation
{
    public class UpdateObjectionValidation : AbstractValidator<UpdateObjectionDTO>
    {
        public UpdateObjectionValidation()
        {
        }
    }
}
