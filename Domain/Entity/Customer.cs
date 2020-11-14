using System;
using System.Collections.Generic;

namespace Domain.Entity
{
    public class Customer
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Order> Customer_Orders { get; set; }

        public Customer()
        {

        }
    }
}
