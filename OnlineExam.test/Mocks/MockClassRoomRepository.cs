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
        public static Mock<IClassRoomRepository> MockSetup()
        {
            var mock = new Mock<IClassRoomRepository>();

            //Get All
            var getAllClassRoom = new PaginateResponse<GetClassRoomDTO>()
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
            mock.Setup(e => e.GetAllAsync<GetClassRoomDTO>(It.IsAny<PaginateRequestDTO>())).ReturnsAsync(getAllClassRoom);
        
            //Get By Id
            var getClassRoomById = new GetClassRoomDTO()
            {
                ClassName = "کلاس تست",
                Id = 1,
                TeacherId = Guid.NewGuid().ToString()
            };
            mock.Setup(e => e.GetAsync<GetClassRoomDTO>(It.IsAny<int>())).ReturnsAsync(getClassRoomById);

            //Get Enitity By id
            var getClassRoomEntityById = new ClassRoom()
            {
                ClassName = "کلاس تست",
                Id = 1,
                TeacherId = Guid.NewGuid().ToString(),
                CreatedDate = DateTime.Now,
                ModifiedDate=DateTime.Now.AddDays(1)
            };
            mock.Setup(e => e.GetAsync(It.IsAny<int>())).ReturnsAsync(getClassRoomEntityById);
            //Add Async
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
            
            //Is User teacher
            mock.Setup(e=>e.IsUserTeacherAsync(It.IsAny<int>(),It.IsAny<string>())).ReturnsAsync(true);

            //Get Student Classess
            var studentClasses = new PaginateResponse<GetClassRoomStudentDTO>()
            {
                PageNumber = 1,
                PageCount = 10,
                TotalCount = 100,
                TotalPage = 10,
                Data = new List<GetClassRoomStudentDTO>()
                {
                    new GetClassRoomStudentDTO()
                    {
                        ClassName="کلاس دانشجو",
                        Id=1,
                    },
                    new GetClassRoomStudentDTO()
                    {
                        ClassName="کلاس دانشجو 2",
                        Id=2,
                    }
                }

            };
            mock.Setup(e => e.GetStudentClassesAsync(It.IsAny<string>(), It.IsAny<PaginateRequestDTO>())).ReturnsAsync(studentClasses);

            //Get Teacher Classess
            var teacherClassess = new PaginateResponse<GetClassRoomTeacherDTO>()
            {
                PageCount = 10,
                PageNumber = 1,
                TotalCount = 10,
                TotalPage = 1,
                Data = new List<GetClassRoomTeacherDTO>()
                {
                    new GetClassRoomTeacherDTO()
                    {
                        ClassName="کلاس دانشجو",
                        Id=5,

                    }
                }
            };
            mock.Setup(e => e.GetTeacherClassAsync(It.IsAny<string>(), It.IsAny<PaginateRequestDTO>())).ReturnsAsync(teacherClassess);

            //Update Class Room
            mock.Setup(e => e.UpdateAsync(It.IsAny<int>(), It.IsAny<UpdateClassRoomDTO>()));
            return mock;
        }


    }
}
