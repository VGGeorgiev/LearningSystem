namespace LearningSystem.Infrastructure.Repositories
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DataContext context) : base(context)
        {

        }

        public Course GetDetailedCourse(int id)
        {
            var course = this.context.Courses
                .Include(x => x.Lectures)
                .ThenInclude(l => l.HomeworkAssignments)
                .FirstOrDefault(x => x.Id == id);
            return course;
        }
    }
}
