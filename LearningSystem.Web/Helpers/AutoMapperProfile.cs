namespace LearningSystem.Web.Helpers
{
    using AutoMapper;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Dtos;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Season, SeasonDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Course, CourseDetailDto>();
            CreateMap<HomeworkAssignment, HomeworkAssignmentDto>();
            CreateMap<Lecture, LectureDto>();
        }
    }
}