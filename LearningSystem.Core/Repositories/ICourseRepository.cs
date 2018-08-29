namespace LearningSystem.Core.Repositories
{
    using LearningSystem.Core.Entities;

    public interface ICourseRepository
    {
        Course GetDetailedCourse(int id); 
    }
}
