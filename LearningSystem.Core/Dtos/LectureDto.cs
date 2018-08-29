using System.Collections.Generic;

namespace LearningSystem.Core.Dtos
{
    public class LectureDto
    {
        public string Name { get; set; }
        
        public string VideoUrl { get; set; }

        public List<HomeworkAssignmentDto> HomeworkAssignments { get; set; }
    }
}