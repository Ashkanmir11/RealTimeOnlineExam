using FluentValidation;
using Moq;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Application.DTOs.Exam.Validation;
using OnlineExam.Application.Features.Exam.Handler.Commands;
using OnlineExam.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Features.Exam.Request.Commands;

namespace OnlineExam.Test.Exam.Commands
{
    public class CreateExamRequestHandlerTest
    {
        private readonly Mock<IExamRepository> _examRepository;
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        private readonly IValidator<CreateExamDTO> _validator;
        public CreateExamRequestHandlerTest()
        {
            _classRoomRepository = MockClassRoomRepository.MockSetup();
            _examRepository = MockExamRepository.MockSetup();
            _validator = new CreateExamValidation(_classRoomRepository.Object);
        }
        [Fact]
        public async Task CreateExam()
        {
            //Arrange
            var newExam = new CreateExamDTO()
            {
                Name = "آزمون تست",
                Description = "ندارد",
                AllowedDelay = 15,
                StartDate = DateTime.Now.AddMinutes(5),
                EndDate = DateTime.Now.AddMinutes(65),
                AllowedCopy = true,
                ClassId = 1,
                LogStudent = false,
                QuestionCount = 10,
                RandomQuestions = true,
            };
            //Act
            var handler = new CreateExamRequestHandler(_examRepository.Object, _validator);
            await handler.Handle(new CreateExamRequest() { CreateExamDTO = newExam }, CancellationToken.None);
            //Assert
            _examRepository.Verify(e => e.AddAsync<CreateExamDTO>(It.Is<CreateExamDTO>(e => e.Name == newExam.Name
            && e.ClassId == newExam.ClassId
            && e.QuestionCount == newExam.QuestionCount
            && e.StartDate == newExam.StartDate
            && e.EndDate == newExam.EndDate)));
        }
    }
}
