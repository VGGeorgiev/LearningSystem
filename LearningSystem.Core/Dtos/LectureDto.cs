using System.Collections.Generic;

namespace LearningSystem.Core.Dtos
{
    public class LectureDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public List<HomeworkAssignmentDto> HomeworkAssignments { get; set; }
    }

    public class LectureShortDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoUrl { get; set; }

        public int CourseId { get; set; }

        public string CourseName { get; set; }
    }
}