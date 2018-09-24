namespace LearningSystem.Infrastructure
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DataContext context;
        protected DbSet<TEntity> entities;
        protected IQueryable<TEntity> queriableEntities;
        string errorMessage = string.Empty;

        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
            queriableEntities = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return queriableEntities.AsEnumerable();
        }

        public TEntity Get(int id)
        {
            return queriableEntities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            ((IAuditInfo)entity).CreatedDate = DateTime.Now;

            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var entityDb = this.Get(entity.Id);
            context.Entry(entityDb).State = EntityState.Detached;
            ((IAuditInfo)entity).CreatedDate = ((IAuditInfo)entityDb).CreatedDate;
            ((IAuditInfo)entity).ModifiedDate = DateTime.Now;

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
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
        
        public IRepository<TEntity> Include<TProperty>(Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            queriableEntities = queriableEntities.Include(navigationPropertyPath);
            return this;
        }
        
        public IRepository<TEntity> ThenInclude<TPreviousProperty, TProperty>(Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath)
        {
            var includableQueryableEntities = queriableEntities as IIncludableQueryable<TEntity, TPreviousProperty>;
            if (includableQueryableEntities != null)
            {
                queriableEntities = includableQueryableEntities.ThenInclude(navigationPropertyPath);
            }
            else
            {
                var includableQueryableListEntities = queriableEntities as IIncludableQueryable<TEntity, List<TPreviousProperty>>;
                queriableEntities = includableQueryableListEntities.ThenInclude(navigationPropertyPath);
            }

            return this;
        }
    }
}