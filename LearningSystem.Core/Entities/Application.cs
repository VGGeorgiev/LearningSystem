namespace LearningSystem.Core.Entities
{
    public class Application : BaseEntity
    {
        public int SeasonId { get; set; }

        public Season Season { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public bool IsApproved { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal HighSchoolGrade { get; set; }

        public byte[] Documents { get; set; }
    }
}
