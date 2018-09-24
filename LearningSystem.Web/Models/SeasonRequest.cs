namespace LearningSystem.Web.Models
{
    using System;

    public class SeasonRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int StudentsLimit { get; set; }
    }
}
