using Domain.Entity;

namespace Domain.IRepository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Product GetByCodigoBarras(string codigoBarras);
    }
}
