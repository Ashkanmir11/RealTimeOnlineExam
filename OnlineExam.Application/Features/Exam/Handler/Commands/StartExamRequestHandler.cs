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
namespace OnlineExam.Application.Features.Exam.Handler.Commands
{
    public class StartExamRequestHandler : IRequestHandler<StartExamRequest>
    {
        private readonly IExamRepository _examRepository;
        private readonly IClassRoomMembersRepository _classRoomMembersRepository;
        private readonly IAuthServices _authServices;
        public StartExamRequestHandler(IExamRepository examRepository, IClassRoomMembersRepository classRoomMembersRepository, IAuthServices authServices)
        {
            _examRepository = examRepository;
            _classRoomMembersRepository = classRoomMembersRepository;
            _authServices = authServices;
        }

        public async Task Handle(StartExamRequest request, CancellationToken cancellationToken)
        {
            //Check User Is In class
            var currentUserId = await _authServices.GetCurrentUserIdAsync();
            var studentExist = await _classRoomMembersRepository.StudentIsInClassAsync(currentUserId, request.ExamId);
            if (studentExist == false)
            {
                throw new UnauthorizedAccessException("شما دسترسی به این آزمون ندارید.");
            }
            //Check Time
            var exam =await _examRepository.GetAsync(request.ExamId);
            var startWIthDelay = exam.StartDate.Value.AddMinutes(exam.AllowedDelay);
            if(DateTime.Now<exam.StartDate)
            {
                throw new UnauthorizedAccessException("این آزمون هنوز شروع نشده است.");
            }
            if(DateTime.Now >startWIthDelay)
            {
                throw new UnauthorizedAccessException("مهلت شروع آزمون گذشته است.");
            }

            throw new NotImplementedException();

            //TODO create random get questions
            //var question=new QuestionDTO()
            //{
            //    var 
            //}
        }
    }
}
