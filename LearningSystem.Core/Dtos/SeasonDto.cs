namespace LearningSystem.Core.Dtos
{
    using System;

    public class SeasonDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int StudentsLimit { get; set; }
    }
}
