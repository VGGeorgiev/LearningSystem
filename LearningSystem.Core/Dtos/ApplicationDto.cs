namespace LearningSystem.Core.Dtos
{
    public class ApplicationDto
    {
        public int SeasonId { get; set; }
        
        public int UserId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal HighSchoolGrade { get; set; }

        public byte[] Documents { get; set; }
    }
}
