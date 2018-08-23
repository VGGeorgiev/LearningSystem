using AutoMapper;
using LearningSystem.Web.Dtos;
using LearningSystem.Web.Entities;

namespace LearningSystem.Web.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}