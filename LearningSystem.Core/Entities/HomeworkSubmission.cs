namespace LearningSystem.Core.Entities
{
    using System.Collections.Generic;

    public class HomeworkSubmission : BaseEntity
    {
        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public byte[] File { get; set; }

        public List<HomeworkEvaluation> HomeworkEvaluations { get; set; }
    }
}
