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
            CreateMap<Course, CourseDetailDto>();
            CreateMap<HomeworkAssignment, HomeworkAssignmentDto>()
                .ForMember(x => x.HasUserSubmission, x => x.MapFrom(m => m.Lecture.Course.Lectures
                .Where(l => l.Id == m.LectureId)
                .SelectMany(ha => ha.HomeworkAssignments)
                .Where(ha => ha.Id == m.Id)
                .Select(ha => ha.HomeworkSubmissions.Any(hs => hs.UserId == int.Parse(httpContextAccessor.HttpContext.User.Identity.Name)))
                .FirstOrDefault()));
            
            CreateMap<Lecture, LectureDto>();
            CreateMap<ApplicationRequest, ApplicationDto>();
            CreateMap<HomeworkEvaluationDto, HomeworkEvaluation>()
                .ForMember(x => x.EvaluatedById, x => x.MapFrom(m => int.Parse(httpContextAccessor.HttpContext.User.Identity.Name)));
            CreateMap<User, UserDetailDto>();
            CreateMap<Feedback, FeedbackDto>()
                .ForMember(x => x.Reporter, x => x.MapFrom(m => m.Reporter.Username));
            CreateMap<FeedbackDto, Feedback>()
                .ForMember(x => x.ReporterId, x => x.MapFrom(m => int.Parse(httpContextAccessor.HttpContext.User.Identity.Name)))
                .ForMember(x => x.Reporter, x => x.Ignore());

            
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