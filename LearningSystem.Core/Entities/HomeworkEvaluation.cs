namespace LearningSystem.Core.Entities
{
    public class HomeworkEvaluation : BaseEntity
    {
        public string Description { get; set; }

        public int Valuation { get; set; }

        public int HomeworkSubmissionId { get; set; }

        public HomeworkSubmission HomeworkSubmission { get; set; }

        public int EvaluatedById { get; set; }

        public User EvaluatedBy { get; set; }
    }
}
