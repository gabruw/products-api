using System;
using System.Collections.Generic;

namespace Domain.IRepository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Incluid(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetbyId(long Id);
    }
}
