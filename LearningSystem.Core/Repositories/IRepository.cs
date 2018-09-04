namespace LearningSystem.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using LearningSystem.Core.Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        
        T Get(int id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
        
        void SaveChanges();

        IRepository<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath);

        IRepository<T> ThenInclude<TPreviousProperty, TProperty>(Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath);
    }
}
