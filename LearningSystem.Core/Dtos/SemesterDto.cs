namespace LearningSystem.Core.Dtos
{
    using System.Collections.Generic;

    public class SemesterDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CourseDto> Courses { get; set; }
    }
}
