namespace LearningSystem.Web.Models
{
    public class CourseRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }

        public int SemesterId { get; set; }
    }
}
