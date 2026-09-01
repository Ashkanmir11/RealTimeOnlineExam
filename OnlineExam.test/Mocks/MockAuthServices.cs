using Moq;
using OnlineExam.Application.Contracts.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.Mocks
{
    public static class MockAuthServices
    {
        public static Mock<IAuthServices> MockSetup()
        {
            var userId= Guid.NewGuid().ToString();

            var mock = new Mock<IAuthServices>();
            mock.Setup(e=>e.GetCurrentUserIdAsync()).ReturnsAsync(userId);

            mock.Setup(e=>e.IsUserAdminAsync(It.IsAny<string>())).ReturnsAsync(true);
            return mock;
        }
    }
}
