namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ICourseService
    {
        CourseDetailDto GetCourse(int id, int userId);

        IEnumerable<CourseWithSemesterDto> GetAll();

        void Insert(Course courseModel);

        void Edit(Course courseModel);

        void Delete(int id);
    }
}
