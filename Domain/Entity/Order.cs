using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Order
    {
        public long Codigo { get; set; }
        public DateTime Data { get; set; }
        public virtual Customer Order_Customer { get; set; }
        public virtual ICollection<Product> Order_Products { get; set; }

        public Order()
        {

        }
    }
}
