using Domain.Entity;
using System.Collections.Generic;

namespace Domain.IRepository
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> GetAllByCustomer(string cpf);
    }
}
