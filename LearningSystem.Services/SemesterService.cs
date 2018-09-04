using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LearningSystem.Core.Dtos;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Repositories;
using LearningSystem.Core.Services;

namespace LearningSystem.Services
{
    public class SemesterService : ISemesterService
    {
        private IRepository<Semester> semesterRepository;

        public SemesterService(IRepository<Semester> semesterRepository)
        {
            this.semesterRepository = semesterRepository;
        }

        public IEnumerable<SemesterDto> GetSemestersWithCourses()
        {
            var semesters = this.semesterRepository
                .Include(x => x.CoursesInSemester)
                .ThenInclude<CourseInSemester, Course>(x => x.Course)
                .GetAll();
            var semestersDto = semesters.Select(x => new SemesterDto() {
                Id = x.Id,
                Name = x.Name,
                Courses = x.CoursesInSemester.Select(c => new CourseDto() {
                    Id = c.Course.Id,
                    Name = c.Course.Name,
                    Credits = c.Course.Credits
                })
            });
            return semestersDto;
        }
    }
}
