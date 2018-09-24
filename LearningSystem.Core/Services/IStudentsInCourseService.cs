using LearningSystem.Core.Dtos;
using System.Collections.Generic;

namespace LearningSystem.Core.Services
{
    public interface IStudentsInCourseService
    {
        void EnrollStudentsInCourse(int courseId, int seasonId);

        IEnumerable<UserInCourseDto> GetUserInCourses(int userId);

        void ChangeGrade(int userInCourseId, decimal grade);
    }
}
