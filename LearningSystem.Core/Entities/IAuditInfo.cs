namespace LearningSystem.Core.Entities
{
    using System;

    public interface IAuditInfo : IEntity
    {
        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}
