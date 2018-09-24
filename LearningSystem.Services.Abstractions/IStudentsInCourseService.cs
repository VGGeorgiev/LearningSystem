namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using System.Collections.Generic;

    public interface IStudentsInCourseService
    {
        void EnrollStudentsInCourse(int courseId, int seasonId);

        IEnumerable<UserInCourseDto> GetUserInCourses(int userId);

        void ChangeGrade(int userInCourseId, decimal grade);
    }
}
