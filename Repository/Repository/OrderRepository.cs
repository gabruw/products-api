using Domain.Entity;
using Domain.IRepository;
using Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProductContext productContext) : base(productContext)
        {

        }

        public IEnumerable<Order> GetAllByCustomer(string cpf)
        {
            return ProductProvider.Set<Order>().Where(o => o.Order_Customer.Cpf == cpf);
        }

        public Order IncludeOrder(Order order)
        {
            foreach (Product product in order.Order_Products)
            {
                ProductProvider.Attach<Product>(product);
            }

            ProductProvider.Order.Add(order);
            ProductProvider.SaveChanges();
        }

        public Order UpdateOrder(Order order)
        {
            foreach (Product product in order.Order_Products)
            {
                ProductProvider.Attach<Product>(product);
            }

            ProductProvider.Order.Update(order);
            ProductProvider.SaveChanges();
        }
    }
}