using FluentValidation;
using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoom.Validation;
using OnlineExam.Application.Features.ClassRoom.Handler.Command;
using OnlineExam.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.ClassRoomTest.Handlers.Commands
{
    public class UpdateClassRoomRequestHandlerTest
    {
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        private readonly Mock<IAuthServices> _authServices;
        private readonly IValidator<UpdateClassRoomDTO> _validator;
        public UpdateClassRoomRequestHandlerTest()
        {
            _classRoomRepository = MockClassRoomRepository.MockSetup();
            _authServices = MockAuthServices.MockSetup();
            _validator = new UpdateClassRoomValidation();
        }
        [Fact]
        public async Task UpdateClassRoom()
        {
            //Arrange
            int id = 1;
            var data = new UpdateClassRoomDTO()
            {
                ClassName = "کلاس تست آپدیت"
            };

            //Act
            var handler = new UpdateClassRoomRequestHandler(_classRoomRepository.Object, _authServices.Object, _validator);
            await handler.Handle(new Application.Features.ClassRoom.Request.Command.UpdateClassRoomRequest() { Id =id, UpdateClassRoomDTO = data, }, CancellationToken.None);

            //Assert
            _authServices.Verify(e => e.GetCurrentUserIdAsync(), Times.Once());
            _authServices.Verify(e => e.IsUserAdminAsync(It.IsAny<string>()), Times.Once());
            _classRoomRepository.Verify(x => x.UpdateAsync(id, It.Is<UpdateClassRoomDTO>(x => x.ClassName == data.ClassName)), Times.Once);

        }
    }
}
