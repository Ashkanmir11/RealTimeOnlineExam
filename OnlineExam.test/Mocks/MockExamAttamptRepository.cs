using Moq;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockExamAttamptRepository
    {
        public static Mock<IExamAttamptRepository> MockSetup()
        {
            var mock=new Mock<IExamAttamptRepository>();
            var endedExamAttampt = new List<ExamAttampt>()
            {
                new ExamAttampt()
                {
                    Id = 1,
                    ExamId=1,
                    StartDate = DateTime.Now.AddDays(1),
                    EndDate = DateTime.Now.AddDays(1).AddMinutes(30),
                    StudentId=Guid.NewGuid().ToString(),
                    IsEnded=true,
                }
            };
            mock.Setup(e => e.GetTimeoutExamAttampt()).ReturnsAsync(endedExamAttampt);

            mock.Setup(e => e.ExamEndedAsync(It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(false);
            return mock;
        }
    }
}
