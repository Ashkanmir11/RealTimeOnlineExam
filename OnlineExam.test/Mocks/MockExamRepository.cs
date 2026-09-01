using FluentValidation;
using Moq;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.Exam;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockExamRepository
    {
        public static Mock<IExamRepository> MockSetup()
        {
            var mock = new Mock<IExamRepository>();
            mock.Setup(e => e.AddAsync<CreateExamDTO>(It.IsAny<CreateExamDTO>()));
            mock.Setup(e => e.IsUserTeacherAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);

            //Get Exam Entity By Id
            var examEntity = new Domain.Entities.Exam()
            {
                Id = 1,
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
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now.AddMonths(1),
            };
            mock.Setup(e => e.GetAsync(It.IsAny<int>())).ReturnsAsync(examEntity);

            //delete
            mock.Setup(e => e.DeleteAsync(It.IsAny<Domain.Entities.Exam>()));
            return mock;
        }

    }
}
