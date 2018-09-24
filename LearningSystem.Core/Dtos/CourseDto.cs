namespace LearningSystem.Core.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }
    }

    public class CourseWithSemesterDto : CourseDto
    {
        public string SemesterName { get; set; }
    }
}