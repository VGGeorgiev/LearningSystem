namespace LearningSystem.Core.Dtos
{
    using System.Collections.Generic;

    public class SemesterDto : SemesterShortDto
    {
        public IEnumerable<CourseDto> Courses { get; set; }
    }

    public class SemesterShortDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
