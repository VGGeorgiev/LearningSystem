using System;
using System.Collections.Generic;

namespace LearningSystem.Core.Entities
{
    public class HomeworkAssignment : AuditInfo, IEntity
    {
        public string Content { get; set; }

        public int LectureId { get; set; }

        public Lecture Lecture { get; set; }
        
        public DateTime Deadline { get; set; }

        public List<HomeworkSubmission> HomeworkSubmissions { get; set; }
    }
}
