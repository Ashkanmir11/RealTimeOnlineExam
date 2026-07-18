using MediatR;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Exceptions;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Features.Question.Request.Queries;
using OnlineExam.Application.DTOs.Question;
using OnlineExam.Application.Response;
using OnlineExam.Application.Features.ExamAttampt.Request.Commands;
using OnlineExam.Application.Features.ExamAttampt.Request.Queries;
namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class StartExamRequestHandler : IRequestHandler<StartExamRequest, PaginateResponse<GetQuestionDTO>>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IAuthServices _authServices;
        private readonly IMediator _meditor;
        public StartExamRequestHandler(IExamRepository examRepository, IClassRoomMembersRepository classRoomMembersRepository, IAuthServices authServices, IMediator meditor)
        {
            _examRepository = examRepository;
            _classRoomMembersRepository = classRoomMembersRepository;
            _authServices = authServices;
            _meditor = meditor;
        }

        public async Task<PaginateResponse<GetQuestionDTO>> Handle(StartExamRequest request, CancellationToken cancellationToken)
        {
            //Check User Is In class
            var currentUserId = await _authServices.GetCurrentUserIdAsync();
            var studentExist = await _classRoomMembersRepository.StudentIsInClassAsync(currentUserId, request.ExamId);
            if (studentExist == false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به این آزمون ندارید.");
            }
            //Check Time
            var exam = await _examRepository.GetAsync(request.ExamId);
            var startWIthDelay = exam.StartDate.Value.AddMinutes(exam.AllowedDelay);

            if (DateTime.Now < exam.StartDate)
            {
                throw new UnauthorizedAccessException("این آزمون هنوز شروع نشده است.");
            }
            if (DateTime.Now > startWIthDelay)
            {
                throw new UnauthorizedAccessException("مهلت شروع آزمون گذشته است.");
            }


            //Exam Attampt
            var examStarted = await _meditor.Send(new ExamAttamptStartedRequest() { UserId = currentUserId, ExamId = request.ExamId });
          
            if (examStarted == false)
            {
                var difference = exam.EndDate-exam.StartDate ;
                var totalMinute = difference.Value.TotalMinutes;
                int minute = Convert.ToInt32(totalMinute);
                await _meditor.Send(new CreateExamAttamptRequest() { ExamId = request.ExamId, ExamMinute = minute, UserId = currentUserId });
            }

            var examEnded = await _meditor.Send(new ExamAttamptEndedRequest() { ExamId = request.ExamId, UserId = currentUserId });
            if (examEnded)
            {
                throw new UnauthorizedAccessException("شما قبلا در این آزمون شرکت کرده اید.");
            }
            var questions = await _meditor.Send(new GetQuestionForExamRequest() { ExamId = request.ExamId, RandomQuesiton = exam.RandomQuestions, StudentId = currentUserId, PaginateRequestDTO = request.paginateRequestDTO });
            return questions;
        }
    }
}
