namespace LearningSystem.Web.Helpers
{
    using System.Linq;
    using System.IO;
    using Microsoft.AspNetCore.Http;

    using AutoMapper;

    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Web.Models;
    
    public class AutoMapperProfile : Profile
    {
        private IHttpContextAccessor httpContextAccessor;

        public AutoMapperProfile()
        {
        }

        public AutoMapperProfile(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Season, SeasonDto>()
                .ForMember(x => x.IsUserApplied, x => x.MapFrom(m => m.Applications.Any(a => a.UserId == int.Parse(httpContextAccessor.HttpContext.User.Identity.Name))));
            CreateMap<Course, CourseDto>();
            CreateMap<ApplicationDto, Application>();
            CreateMap<Application, ApplicationDto>();
            CreateMap<Course, CourseDetailDto>();
            CreateMap<HomeworkAssignment, HomeworkAssignmentDto>()
                .ForMember(x => x.HasUserSubmission, x => x.MapFrom(m => true));
            
            CreateMap<Lecture, LectureDto>();
            CreateMap<ApplicationRequest, ApplicationDto>();
            CreateMap<HomeworkEvaluationDto, HomeworkEvaluation>()
                .ForMember(x => x.EvaluatedById, x => x.MapFrom(m => int.Parse(httpContextAccessor.HttpContext.User.Identity.Name)));
            CreateMap<SeasonRequest, Season>();
            CreateMap<Season, SeasonShortDto>();
            CreateMap<Semester, SemesterShortDto>();
            CreateMap<SemesterRequest, Semester>();
            CreateMap<Course, CourseWithSemesterDto>();
            CreateMap<CourseRequest, Course>();
            CreateMap<Lecture, LectureShortDto>();
            CreateMap<LectureRequest, Lecture>();
            CreateMap<HomeworkAssignmentRequest, HomeworkAssignment>();
            CreateMap<HomeworkAssignment, HomeworkAssignmentDto>();
            CreateMap<UserInCourse, UserInCourseDto>();
            
            CreateMap<IFormFile, byte[]>().ConstructUsing(file =>
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyToAsync(memoryStream);
                    var fileByteArray = memoryStream.ToArray();
                    return fileByteArray;
                }
            });
        }
    }
}