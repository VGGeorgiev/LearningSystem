namespace LearningSystem.Core.Entities
{
    public class UserInCourse : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public decimal Grade { get; set; }
    }
}
