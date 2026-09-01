using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.Features.ClassRoom.Handler.Queries;
using OnlineExam.Test.Mocks;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.DTOs.Common;
using Shouldly;
using OnlineExam.Application.Response;
using OnlineExam.Application.DTOs.ClassRoom;

namespace OnlineExam.Test.ClassRoomTest.Handlers.Quesries
{
    public class GetClassRoomTeacherRequestHandlerTest
    {
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        private readonly Mock<IAuthServices> _authServices;
        public GetClassRoomTeacherRequestHandlerTest()
        {
            _classRoomRepository = MockClassRoomRepository.MockSetup();
            _authServices= MockAuthServices.MockSetup();
        }
        [Fact]
        public async Task GetTeacherClassess()
        {
            //Arrange
            PaginateRequestDTO paginateRequestDTO = new PaginateRequestDTO();
            //Act
            var handler = new GetClassRoomTeacherRequestHandler(_classRoomRepository.Object,_authServices.Object);
            var result = await handler.Handle(new GetClassRoomTeacherRequest() { PaginateRequestDTO= paginateRequestDTO },CancellationToken.None);
            //Assert
            _authServices.Verify(e => e.GetCurrentUserIdAsync(), Times.Once());
            result.ShouldBeOfType<PaginateResponse<GetClassRoomTeacherDTO>>();
        }

    }
}
