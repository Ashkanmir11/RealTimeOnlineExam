using Moq;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockDescriptiveAnswersRepository
    {
        public static Mock<IDescriptiveAnswersRepository> MockSetup()
        {
            var mock=new Mock<IDescriptiveAnswersRepository>();
            return mock;
        }
    }
}
