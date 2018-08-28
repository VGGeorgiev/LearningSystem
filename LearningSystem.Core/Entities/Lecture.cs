namespace LearningSystem.Core.Entities
{
    public class Lecture : BaseEntity
    {
        public string Name { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public string VideoUrl { get; set; }
    }
}
