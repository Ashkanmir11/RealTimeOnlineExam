using AutoMapper;
using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Identity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Identity.Profile
{
    public class IdentityMappingProfile : AutoMapper.Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<OnlineExamUser, GetUserDTO>().ReverseMap();
            CreateMap<OnlineExamUser,UserNameAndLastNameDTO>().ReverseMap();
            CreateMap<OnlineExamUser, GetMyUserInfoDTO>().ReverseMap();
        }
    }
}
