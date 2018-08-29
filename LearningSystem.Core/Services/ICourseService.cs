namespace LearningSystem.Core.Services
{
    using LearningSystem.Core.Dtos;

    public interface ICourseService
    {
        CourseDetailDto GetCourse(int id);
    }
}
