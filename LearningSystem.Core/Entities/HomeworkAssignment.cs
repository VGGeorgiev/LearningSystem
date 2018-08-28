using System;

namespace LearningSystem.Core.Entities
{
    public class HomeworkAssignment : BaseEntity
    {
        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public DateTime Deadline { get; set; }
    }
}
