namespace LearningSystem.Core.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int Rating { get; set; }

        public int UserId { get; set; }

        public string Reporter { get; set; }
    }
}