namespace LearningSystem.Core.Dtos
{
    public class HomeworkEvaluationDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Valuation { get; set; }

        public int HomeworkSubmissionId { get; set; }
        
        public int EvaluatedById { get; set; }
    }
}
