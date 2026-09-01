using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineExam.Application.Contracts.Identity;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.ClassRoom.Validation;
using OnlineExam.Application.Features.ClassRoom.Handler.Command;
using OnlineExam.Application.Features.ClassRoom.Handler.Queries;
using OnlineExam.Application.Features.ClassRoom.Request.Queries;
using OnlineExam.Application.Profile;
using OnlineExam.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Features.ClassRoom.Request.Command;
using Shouldly;
using OnlineExam.Persistence.Repositories;

namespace OnlineExam.Test.ClassRoomTest.Handlers.Commands
{
    public class CreateClassRoomRequestHandlerTest
    {
        private readonly Mock<IClassRoomRepository> _classRoomRepository;
        private readonly IMapper _mapper;
        private readonly Mock<IAuthServices> _authServices;
        private readonly IValidator<CreateClassRoomDTO> _validator;
        private readonly Mock<IAccountRepository> _accountRepository;

        public CreateClassRoomRequestHandlerTest()
        {
            _classRoomRepository = MockClassRoomRepository.MockSetup();
            _authServices=MockAuthServices.MockSetup();
            var mapperConfiguration = new MapperConfiguration(
            cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            },
            LoggerFactory.Create(builder => { }));
            _mapper = mapperConfiguration.CreateMapper();
            _accountRepository = MockAcoountRepository.MockSetup();
            _validator = new CreateClassRoomValidation(_accountRepository.Object);
        }
        [Fact]
        public async Task AddClassRoom()
        {
            //Arange
            var requestData = new CreateClassRoomDTO()
            {
                ClassName = "Class Test",
                TeacherId = Guid.NewGuid().ToString()
            };
            //Act
            var handler = new CreateClassRoomRequestHandler(_classRoomRepository.Object,_mapper,_authServices.Object,_validator);
            var result = await handler.Handle(new CreateClassRoomRequest() { CreateClassRoomDTO= requestData },CancellationToken.None);

            //Assert
            _classRoomRepository.Verify(e=>e.AddAsync(It.Is<CreateClassRoomDTO>(e=> e.ClassName == requestData.ClassName && e.TeacherId == requestData.TeacherId)), Times.Once()); 
            result.ShouldBeOfType<GetClassRoomDTO>();
        }
    }
}
