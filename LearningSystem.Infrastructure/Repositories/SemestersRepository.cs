namespace LearningSystem.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using Microsoft.EntityFrameworkCore;
    

    public class SemestersRepository : Repository<Semester>, ISemestersRepository
    {
        public SemestersRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<Semester> GetSemestersWithCourses()
        {
            var semesters = this.entities
                .Include(x => x.CoursesInSemester)
                .ThenInclude(x => x.Course)
                .ToList();

            return semesters;
        }
    }
}
