using System;
using System.Collections.Generic;

namespace LearningSystem.Core.Entities
{
    public class Season : AuditInfo, IEntity
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int StudentsLimit { get; set; }

        public List<Application> Applications { get; set; }
    }
}
