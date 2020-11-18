using Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ProductContext ProductProvider;

        public BaseRepository(ProductContext productProvider)
        {
            ProductProvider = productProvider;
        }

        public TEntity Incluid(TEntity entity)
        {
            ProductProvider.Set<TEntity>().Add(entity);
            ProductProvider.SaveChanges();

            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            ProductProvider.Set<TEntity>().Update(entity);
            ProductProvider.SaveChanges();

            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            ProductProvider.Remove(entity);
            ProductProvider.SaveChanges();

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ProductProvider.Set<TEntity>().ToList();
        }

        public TEntity GetbyId(long Id)
        {
            TEntity entity = ProductProvider.Set<TEntity>().Find(Id);
            ProductProvider.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public void Dispose()
        {
            ProductProvider.Dispose();
        }
    }
}
