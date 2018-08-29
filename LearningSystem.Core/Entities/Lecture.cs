namespace LearningSystem.Core.Entities
{
    using System.Collections.Generic;

    public class Lecture : BaseEntity
    {
        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string VideoUrl { get; set; }

        public List<HomeworkAssignment> HomeworkAssignments { get; set; }
    }
}
