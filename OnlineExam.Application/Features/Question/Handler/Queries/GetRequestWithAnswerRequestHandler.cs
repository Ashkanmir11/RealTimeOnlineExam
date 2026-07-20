using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.Response;
using OpenAI.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Features.Question.Handler.Queries
{
    public class GetRequestWithAnswerRequestHandler : IRequestHandler<GetQuestionWithAnswerRequest, PaginateResponse<GetQuestionTeacherDTO>>
    {
        private readonly IQuestionRepository _quesitonRepository;
        private readonly IExamRepository _examRepository;
        private readonly IAuthServices _authServices;
        public GetRequestWithAnswerRequestHandler(IQuestionRepository quesitonRepository, IExamRepository examRepository,IAuthServices authServices)
        {
            _quesitonRepository = quesitonRepository;
            _examRepository = examRepository;
            _authServices = authServices;
        }

        public async Task<PaginateResponse<GetQuestionTeacherDTO>> Handle(GetQuestionWithAnswerRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _authServices.GetCurrentUserIdAsync();
            var access = await _examRepository.IsUserTeacher(currentUser, request.ExamId);
            if(access==false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به سوالات و پاسخ های این آزمون ندارید.");
            }

            var questions = await _quesitonRepository.GetByExamId<GetQuestionTeacherDTO>(request.ExamId,false,request.StudentId,request.PaginateRequestDTO);
            if (questions == null)
            {
                return null;

            }
            foreach(var question in questions.Data)
            {
                if(question.TrueOrFalseQuestion!=null)
                {
                    
                }
            }

            return questions;
        }
    }
}
