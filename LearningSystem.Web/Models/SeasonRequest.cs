using System;

namespace LearningSystem.Web.Models
{
    public class SeasonRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public int StudentsLimit { get; set; }
    }
}
