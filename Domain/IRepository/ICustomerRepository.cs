﻿using Domain.Entity;

namespace Domain.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Customer GetByCpf(string cpf);
    }
}
