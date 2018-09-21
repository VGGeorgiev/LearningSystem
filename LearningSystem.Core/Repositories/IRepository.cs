namespace LearningSystem.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using LearningSystem.Core.Entities;

    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
        
        void SaveChanges();

        IRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath);

        IRepository<TEntity> ThenInclude<TPreviousProperty, TProperty>(Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath);
    }
}
