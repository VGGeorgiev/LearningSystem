namespace LearningSystem.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationRequest
    {
        public int SeasonId { get; set; }

        public int UserId { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal HighSchoolGrade { get; set; }

        public IFormFile Documents { get; set; }
    }
}
