using System;
using System.Collections.Generic;

namespace CoronaAPI.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetFirst();
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);
        void Remove(Guid id);
        int SaveChanges();
         
    }
}