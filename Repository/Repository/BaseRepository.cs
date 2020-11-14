using Domain.IRepository;
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

        public void Incluid(TEntity entity)
        {
            ProductProvider.Set<TEntity>().Add(entity);
            ProductProvider.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            ProductProvider.Set<TEntity>().Update(entity);
            ProductProvider.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            ProductProvider.Remove(entity);
            ProductProvider.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ProductProvider.Set<TEntity>().ToList();
        }

        public TEntity GetbyId(long Id)
        {
            return ProductProvider.Set<TEntity>().Find(Id);
        }

        public void Dispose()
        {
            ProductProvider.Dispose();
        }
    }
}
