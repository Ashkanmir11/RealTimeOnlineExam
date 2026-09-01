using OnlineExam.Application.DTOs.Identity;
using OnlineExam.Identity.Model;

namespace OnlineExam.Identity.Profile
{
    public class IdentityMappingProfile : AutoMapper.Profile
    {
        public IdentityMappingProfile()
        {
            CreateMap<OnlineExamUser, GetUserDTO>().ReverseMap();
            CreateMap<OnlineExamUser, UserNameAndLastNameDTO>().ReverseMap();
            CreateMap<OnlineExamUser, GetMyUserInfoDTO>().ReverseMap();
        }
    }
}
