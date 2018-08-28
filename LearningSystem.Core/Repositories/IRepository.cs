namespace LearningSystem.Core.Repositories
{
    using System.Collections.Generic;
    using LearningSystem.Core.Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        
        T Get(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        
        void SaveChanges();
    }
}
