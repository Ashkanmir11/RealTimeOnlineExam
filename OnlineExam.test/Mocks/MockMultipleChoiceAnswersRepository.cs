using Moq;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockMultipleChoiceAnswersRepository
    {
        public static Mock<IMultipleChoiceAnswersRepository> MockSetup()
        {
            var mock =new Mock<IMultipleChoiceAnswersRepository>();
            return mock;
        }
    }
}
