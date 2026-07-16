using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.DTOs.DescriptiveAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Commands
{
    public class UpdateDescriptiveAnswersRequestHandler:IRequestHandler<UpdateDescriptiveAnswersRequest>
    {
        private readonly IDescriptiveAnswersRepository _DescriptiveAnswersRepository;
        public UpdateDescriptiveAnswersRequestHandler(IDescriptiveAnswersRepository DescriptiveAnswersRepository)
        {
            _DescriptiveAnswersRepository = DescriptiveAnswersRepository;
        }

        public async Task Handle(UpdateDescriptiveAnswersRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDescriptiveAnswersValidation(_DescriptiveAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateDescriptiveAnswersDTO);
            if(validationResult.IsValid==false)
            {
                var massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new BadRequestException(massage);
            }
            await _DescriptiveAnswersRepository.UpdateAsync(request.UpdateDescriptiveAnswersDTO.Id, request.UpdateDescriptiveAnswersDTO);
        }
    }
}
