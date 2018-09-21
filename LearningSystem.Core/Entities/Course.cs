using System.Collections.Generic;

namespace LearningSystem.Core.Entities
{
    public class Course : AuditInfo, IEntity
    {
        public string Name { get; set; }

        public int Credits { get; set; }

        public List<CourseInSemester> CoursesInSemester { get; set; }

        public List<Lecture> Lectures { get; set; }
    }
}
