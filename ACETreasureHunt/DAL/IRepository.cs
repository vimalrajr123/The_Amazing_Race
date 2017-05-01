﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ACETreasureHunt.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);



        //TEntity Get(int id);
        //IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);

        //int SaveChanges();


        //Task<TEntity> GetAsync(int id);
        //Task<IEnumerable<TEntity>> GetAllAsync();
        //Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        //Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        //Task<int> AddAsync(TEntity entity);
        //Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

        //Task<int> RemoveAsync(TEntity entity);
        //Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

        //Task<int> SaveChangesAsync();
    }
}