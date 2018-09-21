namespace LearningSystem.Core.Entities
{
    public class CourseInSemester : AuditInfo, IEntity
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int SemesterId { get; set; }

        public Semester Semester { get; set; }
    }
}
