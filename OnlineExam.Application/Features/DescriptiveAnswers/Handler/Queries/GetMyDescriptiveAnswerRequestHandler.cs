using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.DescriptiveAnswers;
using OnlineExam.Application.Features.DescriptiveAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.DescriptiveAnswers.Handler.Queries
{
    public class GetMyDescriptiveAnswerRequestHandler : IRequestHandler<GetMyDescriptiveAnswerRequest, GetDescriptiveAnswerStudentDTO>
    {
        private readonly IDescriptiveAnswersRepository _descriptiveAnswersRepository;
        private readonly IAuthServices _authServices;
        public GetMyDescriptiveAnswerRequestHandler(IDescriptiveAnswersRepository descriptiveAnswersRepository, IAuthServices authServices)
        {
            _descriptiveAnswersRepository = descriptiveAnswersRepository;
            _authServices = authServices;
        }

        public async Task<GetDescriptiveAnswerStudentDTO> Handle(GetMyDescriptiveAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            return await _descriptiveAnswersRepository.GetForStudent(currentUser, request.descriptiveQuestionId);
        }
    }
}
