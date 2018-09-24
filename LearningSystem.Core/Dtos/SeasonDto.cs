namespace LearningSystem.Core.Dtos
{
    using System;

    public class SeasonDto : SeasonShortDto
    {
        public bool IsUserApplied { get; set; }
    }

    public class SeasonShortDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int StudentsLimit { get; set; }
    }
}
