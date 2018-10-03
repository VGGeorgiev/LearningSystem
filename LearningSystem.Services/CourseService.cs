namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Services.Abstractions;
    using System.Collections.Generic;
    using System.Linq;

    public class CourseService : ICourseService
    {
        private IRepository<Course> courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public CourseDetailDto GetCourse(int id, int userId)
        {
            var course = this.courseRepository
                .Include(x => x.Lectures)
                .ThenInclude<Lecture, List<HomeworkAssignment>>(x => x.HomeworkAssignments)
                .ThenInclude<HomeworkAssignment, List<HomeworkSubmission>>(x => x.HomeworkSubmissions)                
                .Get(id);
            var courseDto = Mapper.Map<CourseDetailDto>(course);

            foreach (var lecture in courseDto.Lectures)
            {
                foreach (var homeworkAssignment in lecture.HomeworkAssignments)
                {
                    homeworkAssignment.HasUserSubmission = course.Lectures
                        .Where(x => x.Id == lecture.Id)
                        .SelectMany(x => x.HomeworkAssignments)
                        .Where(x => x.Id == homeworkAssignment.Id)
                        .Select(x => x.HomeworkSubmissions.Any(hs => hs.UserId == userId))
                        .FirstOrDefault();
                }
            }

            return courseDto;
        }

        public void Delete(int id)
        {
            var course = this.courseRepository.Get(id);
            this.courseRepository.Delete(course);
        }

        public void Edit(Course course)
        {
            this.courseRepository.Update(course);
        }

        public IEnumerable<CourseWithSemesterDto> GetAll()
        {
            var courses = this.courseRepository
                .Include(x => x.Semester)
                .GetAll();
            var coursesDto = Mapper.Map<IEnumerable<CourseWithSemesterDto>>(courses);
            return coursesDto;
        }

        public void Insert(Course course)
        {
            this.courseRepository.Insert(course);
        }
    }
}
