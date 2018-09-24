namespace LearningSystem.Web.Models
{
    using System;

    public class HomeworkAssignmentRequest
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int LectureId { get; set; }
        
        public DateTime Deadline { get; set; }
    }
}
