namespace LearningSystem.Services.Abstractions
{
    using LearningSystem.Core.Dtos;
    using LearningSystem.Core.Entities;
    using System.Collections.Generic;

    public interface IUserService
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);

        UserDto GetByUsername(string username);

        User Create(User user, string password);

        void Update(User user, string password = null);

        void Delete(int id);

        void MakeStudent(int id);
    }
}
