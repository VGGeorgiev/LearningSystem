using System.Collections.Generic;

namespace LearningSystem.Core.Dtos
{
    public class CourseDetailDto : CourseDto
    {
        public int SemesterId { get; set; }

        public List<LectureDto> Lectures { get; set; }
    }
}
