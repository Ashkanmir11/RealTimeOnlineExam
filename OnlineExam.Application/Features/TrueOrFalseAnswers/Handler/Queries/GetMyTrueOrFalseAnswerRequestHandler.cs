using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.TrueOrFalseAnswers;
using OnlineExam.Application.Features.TrueOrFalseAnswers.Request.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.TrueOrFalseAnswers.Handler.Queries
{
    public class GetMyTrueOrFalseAnswerRequestHandler : IRequestHandler<GetMyTrueOrFalseAnswerRequest, GetTrueOrFalseAnswerStudentDTO>
    {
        private readonly IAuthServices _authServices;
        private readonly ITrueOrFalseAnswersRepository _trueOrFalseAnswersRepository;
        public GetMyTrueOrFalseAnswerRequestHandler(IAuthServices authServices, ITrueOrFalseAnswersRepository trueOrFalseAnswersRepository)
        {
            _authServices = authServices;
            _trueOrFalseAnswersRepository = trueOrFalseAnswersRepository;
        }

        public async Task<GetTrueOrFalseAnswerStudentDTO> Handle(GetMyTrueOrFalseAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            return await _trueOrFalseAnswersRepository.GetForStudent(currentUser, request.TrueOrFalseQuestionId);
        }
    }
}
