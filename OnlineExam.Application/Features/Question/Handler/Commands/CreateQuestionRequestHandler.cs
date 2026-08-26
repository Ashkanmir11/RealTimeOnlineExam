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
namespace OnlineExam.Application.Features.Question.Handler.Commands
{
    public class CreateQuestionRequestHandler : IRequestHandler<CreateQuestionRequest>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateQuestionDTO> _validatorQuestion;
        private readonly IMediator _mediator;

        public CreateQuestionRequestHandler(IQuestionRepository questionRepository, IMapper mapper, IValidator<CreateQuestionDTO> validatorQuestion, IMediator mediator)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
            _mediator = mediator;
            _validatorQuestion = validatorQuestion;
        }

        public async Task Handle(CreateQuestionRequest request, CancellationToken cancellationToken)
        {

            var questionValidator = await _validatorQuestion.ValidateAsync(request.CreateQuestionDTO);
            if (questionValidator.IsValid == false)
            {
                var errors = questionValidator.Errors.Select(e => e.ErrorMessage).ToList();
                throw new Application.Exceptions.ValidationException(errors);

            }


            if (request.CreateQuestionDTO.TrueOrFalseQuestion != null)
            {
                var questionDetail = _mapper.Map<CreateTrueOrFalseQuestionDTO>(request.CreateQuestionDTO.TrueOrFalseQuestion);
                request.CreateQuestionDTO.TrueOrFalseQuestionId = await _mediator.Send(new CreateTrueOrFalseQuestionRequest() { CreateTrueOrFalseQuestionDTO = questionDetail });
            }
            else if (request.CreateQuestionDTO.DescriptiveQuestion != null)
            {
                var questionDetail = _mapper.Map<CreateDescriptiveQuestionDTO>(request.CreateQuestionDTO.DescriptiveQuestion);
                request.CreateQuestionDTO.DescriptiveQuestionId = await _mediator.Send(new CreateDescriptiveQuestionRequest() { CreateDescriptiveQuestionDTO = questionDetail });
            }
            else
            {
                var questionDetail = _mapper.Map<CreateMultipleChoiceQuestionDTO>(request.CreateQuestionDTO.MultipleChoiceQuestion);
                request.CreateQuestionDTO.MultipleChoiceQuestionId = await _mediator.Send(new CreateMultipleChoiceQuestionRequest() { CreateMultipleChoiceQuestionDTO = questionDetail });
            }
            request.CreateQuestionDTO.DescriptiveQuestion = null;
            request.CreateQuestionDTO.TrueOrFalseQuestion = null;
            request.CreateQuestionDTO.MultipleChoiceQuestion = null;
            var quesiton = await _questionRepository.AddAsync<CreateQuestionDTO>(request.CreateQuestionDTO);

        }
    }
}
