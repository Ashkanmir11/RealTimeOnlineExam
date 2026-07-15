using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers;
using OnlineExam.Application.DTOs.DescriptiveQuestionAnswers.Validation;
using OnlineExam.Application.Features.DescriptiveQuestionAnswers.Request.Commands;
using OnlineExam.Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
namespace OnlineExam.Application.Features.DescriptiveQuestionAnswers.Handler.Commands
{
    public class UpdateDescriptiveQuestionAnswersRequestHandler:IRequestHandler<UpdateDescriptiveQuestionAnswersRequest>
    {
        private readonly IDescriptiveQuestionAnswersRepository _descriptiveQuestionAnswersRepository;
        public UpdateDescriptiveQuestionAnswersRequestHandler(IDescriptiveQuestionAnswersRepository descriptiveQuestionAnswersRepository)
        {
            _descriptiveQuestionAnswersRepository = descriptiveQuestionAnswersRepository;
        }

        public async Task Handle(UpdateDescriptiveQuestionAnswersRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDescriptiveQuestionAnswersValidation(_descriptiveQuestionAnswersRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateDescriptiveQuestionAnswersDTO);
            if(validationResult.IsValid==false)
            {
                var massage = ListToStringHelper.CreateString(validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                throw new BadRequestException(massage);
            }
            await _descriptiveQuestionAnswersRepository.UpdateAsync(request.UpdateDescriptiveQuestionAnswersDTO.Id, request.UpdateDescriptiveQuestionAnswersDTO);
        }
    }
}
