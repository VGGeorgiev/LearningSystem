namespace LearningSystem.Web.Helpers
{
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Web.Dtos;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}