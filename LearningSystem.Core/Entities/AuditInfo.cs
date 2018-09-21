namespace LearningSystem.Core.Entities
{
    using System;

    public abstract class AuditInfo : IAuditInfo, IEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
