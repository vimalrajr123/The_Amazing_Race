using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace ACETreasureHunt.DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
             
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }




        //public TEntity Get(int id)
        //{
        //    return context.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> GetAll()
        //{
        //    return context.Set<TEntity>().ToList();
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return context.Set<TEntity>().Where(predicate);
        //}

        //public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return context.Set<TEntity>().SingleOrDefault(predicate);
        //}

        //public void Add(TEntity entity)
        //{
        //    context.Set<TEntity>().Add(entity);
        //    context.SaveChanges();
        //}

        //public void AddRange(IEnumerable<TEntity> entities)
        //{
        //    context.Set<TEntity>().AddRange(entities);
        //    context.SaveChanges();
        //}

        //public void Remove(TEntity entity)
        //{
        //    context.Set<TEntity>().Remove(entity);
        //    context.SaveChanges();
        //}

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    context.Set<TEntity>().RemoveRange(entities);
        //    context.SaveChanges();
        //}

        //public async Task<TEntity> GetAsync(int id)
        //{
        //    return await context.Set<TEntity>().FindAsync(id);
        //}

        //public async Task<IEnumerable<TEntity>> GetAllAsync()
        //{
        //    return await context.Set<TEntity>().ToListAsync();
        //}

        //public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await context.Set<TEntity>().Where<TEntity>(predicate).ToListAsync();
        //}

        //public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return await context.Set<TEntity>().SingleOrDefaultAsync<TEntity>(predicate);
        //}

        //public async Task<int> AddAsync(TEntity entity)
        //{
        //    context.Set<TEntity>().Add(entity);
        //    return await context.SaveChangesAsync();
        //}

        //public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    context.Set<TEntity>().AddRange(entities);
        //    return await context.SaveChangesAsync();
        //}

        //public async Task<int> RemoveAsync(TEntity entity)
        //{
        //    context.Set<TEntity>().Remove(entity);
        //    return await SaveChangesAsync();
        //}

        //public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
        //{
        //    context.Set<TEntity>().RemoveRange(entities);
        //    return await SaveChangesAsync();
        //}

        //public int SaveChanges()
        //{
        //    return context.SaveChanges();
        //}

        //public async Task<int> SaveChangesAsync()
        //{
        //    return await context.SaveChangesAsync();
        //}
    }
}