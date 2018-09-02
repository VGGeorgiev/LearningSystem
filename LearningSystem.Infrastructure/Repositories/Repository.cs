namespace LearningSystem.Infrastructure
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Microsoft.EntityFrameworkCore.Query.Internal;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext context;
        protected DbSet<T> entities;
        protected IQueryable<T> queriableEntities;
        string errorMessage = string.Empty;

        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
            queriableEntities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return queriableEntities.AsEnumerable();
        }

        public T Get(int id)
        {
            return queriableEntities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            context.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
        
        public IRepository<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            queriableEntities = queriableEntities.Include(navigationPropertyPath);
            return this;
        }
        
        public IRepository<T> ThenInclude<TPreviousProperty, TProperty>(Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
        {
            var includableQueryableEntities = queriableEntities as IIncludableQueryable<T, TPreviousProperty>;
            if (includableQueryableEntities != null)
            {
                queriableEntities = includableQueryableEntities.ThenInclude(navigationPropertyPath);
            }
            else
            {
                var includableQueryableListEntities = queriableEntities as IIncludableQueryable<T, List<TPreviousProperty>>;
                queriableEntities = includableQueryableListEntities.ThenInclude(navigationPropertyPath);
            }

            return this;
        }
    }
}