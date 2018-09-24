namespace LearningSystem.Core.Dtos
{
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public UserType Type { get; set; }
    }
}