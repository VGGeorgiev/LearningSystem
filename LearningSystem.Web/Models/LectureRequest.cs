namespace LearningSystem.Web.Models
{
    public class LectureRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public string CourseId { get; set; }
    }
}
