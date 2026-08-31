using MediatR;
using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ClassRoom.Handler.Command;
using OnlineExam.Domain.Entities;
using OnlineExam.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.ClassRoomTest.Handlers.Commands
{
    public class DeleteClassRoomRequstHandlerTest
    {
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        private readonly Mock<IAuthServices> _authServices;
        private readonly Mock<IQuestionRepository> _questionRepository;
        public DeleteClassRoomRequstHandlerTest()
        {
            _classRoomRepository = MockClassRoomRepository.MockSetup();
            _authServices=MockAuthServices.MockSetup();
            _questionRepository = MockQuestionRepository.MockSetup();
        }
        [Fact]
        public async Task DeleteClassRoom()
        {
            //Arrange
            int id = 1;
            //Act
            var handler = new DeleteClassRoomRequstHandler(_classRoomRepository.Object, _authServices.Object, _questionRepository.Object);
            var result = await handler.Handle(new Application.Features.ClassRoom.Request.Command.DeleteClassRoomRequest() { Id = id }, CancellationToken.None);
            //Assert
            _authServices.Verify(e => e.GetCurrentUserIdAsync(), Times.Once());
            _classRoomRepository.Verify(e=>e.DeleteAsync(It.Is<ClassRoom>(e=>e.Id==id)),Times.Once());
            _authServices.Verify(e=>e.IsUserAdminAsync(It.IsAny<string>()), Times.Once());
            _questionRepository.Verify(e => e.RemoveNoRelationQuestionDetail(), Times.Once());
            result.ShouldBeOfType<Unit>();
        }
    }
}
