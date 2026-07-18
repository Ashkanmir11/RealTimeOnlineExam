using AutoMapper;
using FluentValidation;
using MediatR;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveQuestion;
using OnlineExam.Application.DTOs.MultipleChoiceQuestion;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.DTOs.TrueOrFalseQuestion;
using OnlineExam.Application.Features.DescriptiveQuestion.Request.Commands;
using OnlineExam.Application.Features.MultipleChoiceQuestion.Request.Commands;
using OnlineExam.Application.Features.Question.Request.Commands;
using OnlineExam.Application.Features.TrueOrFalseQuestion.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Commands
{
    public class UpdateQuestionRequestHandler : IRequestHandler<UpdateQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IValidator<UpdateQuestionDTO> _validator;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateQuestionRequestHandler(IQuestionRepository questionRepository, IValidator<UpdateQuestionDTO> validator, IMediator mediator, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _validator = validator;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Handle(UpdateQuestionRequest request, CancellationToken cancellationToken)
        {
            var validitonResult = await _validator.ValidateAsync(request.UpdateQuestionDTO);
            if (validitonResult.IsValid == false)
            {
                var errors = validitonResult.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);
            }
            await _questionRepository.DeleteQuestionDetailAsync(request.UpdateQuestionDTO.Id);


            if (request.UpdateQuestionDTO.TrueOrFalseQuestion != null)
            {
                var questionDetail = _mapper.Map<CreateTrueOrFalseQuestionDTO>(request.UpdateQuestionDTO.TrueOrFalseQuestion);
                request.UpdateQuestionDTO.TrueOrFalseQuestionId = await _mediator.Send(new CreateTrueOrFalseQuestionRequest() { CreateTrueOrFalseQuestionDTO = questionDetail });
            }
            else if (request.UpdateQuestionDTO.DescriptiveQuestion != null)
            {
                var questionDetail = _mapper.Map<CreateDescriptiveQuestionDTO>(request.UpdateQuestionDTO.DescriptiveQuestion);
                request.UpdateQuestionDTO.DescriptiveQuestionId = await _mediator.Send(new CreateDescriptiveQuestionRequest() { CreateDescriptiveQuestionDTO = questionDetail });
            }
            else
            {
                var questionDetail = _mapper.Map<CreateMultipleChoiceQuestionDTO>(request.UpdateQuestionDTO.MultipleChoiceQuestion);
                request.UpdateQuestionDTO.MultipleChoiceQuestionId = await _mediator.Send(new CreateMultipleChoiceQuestionRequest() { CreateMultipleChoiceQuestionDTO = questionDetail });
            }
            await _questionRepository.UpdateAsync(request.UpdateQuestionDTO.Id, request.UpdateQuestionDTO);
        }
    }
}
