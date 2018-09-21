namespace LearningSystem.Core.Entities
{
    public class Feedback : AuditInfo, IEntity
    {
        public string Content { get; set; }

        public short Rating { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ReporterId { get; set; }

        public User Reporter { get; set; }
    }
}
