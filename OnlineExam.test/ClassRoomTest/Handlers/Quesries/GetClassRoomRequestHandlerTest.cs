using MediatR;
using Moq;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.Features.ClassRoom.Handler.Queries;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Response;
using OnlineExam.Test.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Test.ClassRoomTest.Handlers.Quesries
{
    public class GetClassRoomRequestHandlerTest
    {
        private readonly Mock<IClassRoomRepository> _mockRepository;
        public GetClassRoomRequestHandlerTest()
        {
            _mockRepository = MockClassRoomRepository.GetAllClassRoom();
        }
        [Fact]
        public async Task GetAllClassRoomTest()
        {

            var handler = new GetClassRoomRequestHandler(_mockRepository.Object);
            var result =await  handler.Handle(new GetClassRoomRequest(), CancellationToken.None);
            result.ShouldBeOfType<PaginateResponse<GetClassRoomDTO>>();
        }

    }
}
