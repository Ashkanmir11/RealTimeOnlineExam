using Moq;
using OnlineExam.Application.Contracts.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockAcoountRepository
    {
        public static Mock<IAccountRepository> UserExistAsync()
        {
            var mock= new Mock<IAccountRepository>();
            mock.Setup(e=>e.UserExistAsync(It.IsAny<string>())).ReturnsAsync(true);
            return mock;
        }
    }
}
