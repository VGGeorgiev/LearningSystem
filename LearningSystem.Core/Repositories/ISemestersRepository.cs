namespace LearningSystem.Core.Repositories
{
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface ISemestersRepository : IRepository<Semester>
    {
        IEnumerable<Semester> GetSemestersWithCourses();
    }
}
