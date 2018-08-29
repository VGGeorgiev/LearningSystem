namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Services;
    using System;

    public class CourseService : ICourseService
    {
        private ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseDetailDto GetCourse(int id)
        {
            var course = this.courseRepository.GetDetailedCourse(id);
            var courseDto = Mapper.Map<CourseDetailDto>(course);
            return courseDto;
        }
    }
}
