using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class OrderEdit : OrderInclude
    {
        [Required(ErrorMessage = "O código deve ser enviado para efetuar a alteração.")]
        public long Codigo { get; set; }

        public OrderEdit()
        {

        }

        public new Order ToOrder()
        {
            Order order = new Order();
            order.Data = Data;
            order.Codigo = Codigo;
            order.Order_Customer = Customer;
            order.Order_Products = Products;

            return order;
        }
    }
}
