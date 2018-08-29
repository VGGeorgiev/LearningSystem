using System.Collections.Generic;

namespace LearningSystem.Core.Dtos
{
    public class CourseDetailDto : CourseDto
    {
        public List<LectureDto> Lectures { get; set; }
    }
}
