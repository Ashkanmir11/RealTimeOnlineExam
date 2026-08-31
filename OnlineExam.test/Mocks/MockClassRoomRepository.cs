using AutoMapper;
using Moq;
using OnlineExam.Application.Contracts.Persistence;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Application.DTOs.Common;
using OnlineExam.Application.Response;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExam.Application.Profile;
using Microsoft.Extensions.Logging;
namespace OnlineExam.Test.Mocks
{
    public static class MockClassRoomRepository
    {
        public static Mock<IClassRoomRepository> GetAllClassRoom()
        {
            var getClassRoom = new PaginateResponse<GetClassRoomDTO>()
            {
                PageCount = 10,
                PageNumber = 1,
                TotalCount = 20,
                TotalPage = 2,
                Data = new List<GetClassRoomDTO>()
                {
                    new GetClassRoomDTO()
                    {
                        ClassName="کلاس تست",
                        Id=1,
                        TeacherId=Guid.NewGuid().ToString(),
                    },
                    new GetClassRoomDTO()
                    {
                        Id=2,
                        ClassName="2 کلاس تست",
                        TeacherId=Guid.NewGuid().ToString(),

                    }
                }
            };
            var mock = new Mock<IClassRoomRepository>();
            mock.Setup(e => e.GetAllAsync<GetClassRoomDTO>(It.IsAny<PaginateRequestDTO>())).ReturnsAsync(getClassRoom);
            return mock;
        }

        public static Mock<IClassRoomRepository> AddClassRoom()
        {
            var mock = new Mock<IClassRoomRepository>();
            mock.Setup(e => e.AddAsync<CreateClassRoomDTO>(It.IsAny<CreateClassRoomDTO>())).ReturnsAsync((CreateClassRoomDTO dto) =>
            {
                return new ClassRoom
                {
                    ClassName = dto.ClassName,
                    TeacherId = dto.TeacherId,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
            });
            return mock;

        }
    }
}
