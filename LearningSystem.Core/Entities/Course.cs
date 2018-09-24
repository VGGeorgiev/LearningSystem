namespace LearningSystem.Core.Entities
{
    using System.Collections.Generic;

    public class Course : AuditInfo, IEntity
    {
        public string Name { get; set; }

        public int Credits { get; set; }

        public int SemesterId { get; set; }

        public Semester Semester { get; set; }

        public List<Lecture> Lectures { get; set; }
    }
}
