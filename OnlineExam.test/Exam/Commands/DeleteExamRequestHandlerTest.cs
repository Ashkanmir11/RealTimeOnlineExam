using Microsoft.Identity.Client;
using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.Exam.Handler.Commands;
using OnlineExam.Test.Mocks;
using OnlineExam.Application.Features.Exam.Request.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Domain.Entities;

namespace OnlineExam.Test.Exam.Commands
{
    public class DeleteExamRequestHandlerTest
    {
        private readonly Mock<IExamRepository> _examRepository;
        private readonly Mock<IAuthServices> _authServices;
        private readonly Mock<IQuestionRepository> _questionRepository;
        public DeleteExamRequestHandlerTest()
        {
            _examRepository = MockExamRepository.MockSetup();
            _authServices = MockAuthServices.MockSetup();
            _questionRepository = MockQuestionRepository.MockSetup();
        }
        [Fact]
        public async Task DeleteExam()
        {
            //Arrange
            int id = 1;
            //Act
            var handler = new DeleteExamRequestHandler(_examRepository.Object, _authServices.Object, _questionRepository.Object);
            await handler.Handle(new DeleteExamRequest() { Id = id }, CancellationToken.None);

            //Assert
            _authServices.Verify(e => e.GetCurrentUserIdAsync());
            _examRepository.Verify(e => e.IsUserTeacherAsync(It.IsAny<string>(), id));
            _authServices.Verify(e => e.IsUserAdminAsync(It.IsAny<string>()));
            _examRepository.Verify(e => e.GetAsync(id));
            _examRepository.Verify(e => e.DeleteAsync(It.Is<Domain.Entities.Exam>(e=>e.Id==id)));
            _questionRepository.Verify(e => e.RemoveNoRelationQuestionDetail());
        }
    }
}
