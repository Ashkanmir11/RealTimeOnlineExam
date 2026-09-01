using Moq;
using OnlineExam.Application.Contracts.AIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockAiServices
    {
        public static Mock<IAiServices> MockSetup()
        {
            var mock = new Mock<IAiServices>(); 
            return mock;
        }
    }
}
