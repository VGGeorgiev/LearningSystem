namespace LearningSystem.Services
{
    using AutoMapper;
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using LearningSystem.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsInCourseService : IStudentsInCourseService
    {
        private IRepository<Season> seasonRepository;
        private IRepository<UserInCourse> userInCourseRepository;

        public StudentsInCourseService(IRepository<Season> seasonRepository, IRepository<UserInCourse> userInCourseRepository)
        {
            this.seasonRepository = seasonRepository;
            this.userInCourseRepository = userInCourseRepository;
        }

        public void ChangeGrade(int userInCourseId, decimal grade)
        {
            var userInCourse = this.userInCourseRepository.Get(userInCourseId);
            userInCourse.Grade = grade;
            this.userInCourseRepository.Update(userInCourse);
        }

        public void EnrollStudentsInCourse(int courseId, int seasonId)
        {
            var season = this.seasonRepository
                .Include(x => x.Applications)
                .Get(seasonId);

            var approvedUsers = season.Applications
                .Where(x => x.IsApproved)
                .Select(x => x.UserId)
                .ToList();

            foreach (var userId in approvedUsers)
            {
                this.userInCourseRepository.Insert(new UserInCourse
                {
                    CourseId = courseId,
                    UserId = userId,
                });
            }
        }

        public IEnumerable<UserInCourseDto> GetUserInCourses(int userId)
        {
            var userInCourses = this.userInCourseRepository
                .Include(x => x.Course)
                .GetAll()
                .Where(x => x.UserId == userId)
                .ToList();
            var userInCoursesDto = Mapper.Map<IEnumerable<UserInCourseDto>>(userInCourses);
            return userInCoursesDto;
        }
    }
}
