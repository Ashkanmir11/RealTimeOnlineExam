using AutoMapper;
using OnlineExam.Application.DTOs.ClassRoom;
using OnlineExam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Application.Profile
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ClassRoom,CreateClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom,GetClassRoomDTO>().ReverseMap();
            CreateMap<ClassRoom,UpdateClassRoomDTO>().ReverseMap();
        }
    }
}
