namespace LearningSystem.Core.Entities
{
    using System.Collections.Generic;

    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public UserType Type { get; set; }

        public List<Application> Applications { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}