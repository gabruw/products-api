using Domain.Entity;
using Domain.IRepository;
using Repository.Context;
using System.Linq;

namespace Repository.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProductContext productContext) : base(productContext)
        {
            
        }

        public Customer GetByCpf(long cpf)
        {
            return ProductProvider.Set<Customer>().SingleOrDefault(c => c.Cpf == cpf);
        }
    }
}