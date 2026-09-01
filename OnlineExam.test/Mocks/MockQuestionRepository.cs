using Moq;
using OnlineExam.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockQuestionRepository
    { 
        public static Mock<IQuestionRepository> MockSetup()
        {
            var mock=new Mock<IQuestionRepository>();
            mock.Setup(e => e.RemoveNoRelationQuestionDetail());
            return mock;
        }
    }
}
