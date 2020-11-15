using Domain.Entity;
using Domain.IRepository;
using Repository.Context;
using System.Linq;

namespace Repository.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductContext productContext) : base(productContext)
        {

        }


        public Product GetByCodigoBarras(string codigoBarras)
        {
            return ProductProvider.Set<Product>().SingleOrDefault(c => c.CodigoBarras == codigoBarras);
        }
    }
}