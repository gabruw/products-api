using Domain.Entity;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class OrderInclude
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Required(ErrorMessage = "O campo 'Data de Nascimento' não pode ser nulo.")]
        public DateTime Data { get; set; }

        public Customer Customer { get; set; }

        [CollectionLength(1, ErrorMessage = "Deve haver ao menos 1 produto para que o pedido seja efetuado.")]
        public  ICollection<Product> Products { get; set; }

        public OrderInclude()
        {

        }

        public Order ToOrder()
        {
            Order order = new Order();
            order.Data = Data;
            order.Order_Customer = Customer;
            order.Order_Products = Products;

            return order;
        }
    }
}
