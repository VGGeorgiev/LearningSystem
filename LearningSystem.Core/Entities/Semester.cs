namespace LearningSystem.Core.Entities
{
    using System.Collections.Generic;

    public class Semester : AuditInfo, IEntity
    {
        public string Name { get; set; }

        public List<CourseInSemester> CoursesInSemester { get; set; }
    }
}
