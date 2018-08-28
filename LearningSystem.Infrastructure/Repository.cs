namespace LearningSystem.Infrastructure
{
    using LearningSystem.Core.Entities;
    using LearningSystem.Core.Repositories;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(DataContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Get(int id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
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
    }
}