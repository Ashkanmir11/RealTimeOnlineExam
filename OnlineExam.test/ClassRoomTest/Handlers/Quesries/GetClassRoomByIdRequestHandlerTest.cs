using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ClassRoom.Handler.Queries;
using OnlineExam.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using Shouldly;
using OnlineExam.Application.DTOs.ClassRoom;
namespace OnlineExam.Test.ClassRoomTest.Handlers.Quesries
{
    public class GetClassRoomByIdRequestHandlerTest
    {
        private readonly Mock<IAuthServices> _authServices;
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        public GetClassRoomByIdRequestHandlerTest()
        {
            _authServices = MockAuthServices.MockSetup();
            _classRoomRepository = MockClassRoomRepository.MockSetup();
        }

        [Fact]
        public async Task GetClassRoomById()
        {
            //Arrange
            int id = 1;
            //Act
            var handler = new GetClassRoomByIdRequestHandler(_classRoomRepository.Object, _authServices.Object);
            var result = await handler.Handle(new GetClassRoomByIdRequest() { Id = id }, CancellationToken.None);
            //Assert
            _authServices.Verify(e=>e.GetCurrentUserIdAsync(), Times.Once());
            _classRoomRepository.Verify(e => e.IsUserTeacherAsync(id,It.IsAny<string>()), Times.Once());
            _classRoomRepository.Verify(e=>e.GetAsync<GetClassRoomDTO>(id),Times.Once());
            result.ShouldBeOfType<GetClassRoomDTO>();
        }
    }
}
