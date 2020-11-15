using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class CustomerEdit : CustomerInclude
    {
        [Required(ErrorMessage = "O código deve ser enviado para efetuar a alteração.")]
        public long Codigo { get; set; }

        public CustomerEdit()
        {

        }

        public new Customer ToCostumer()
        {
            Customer customer = new Customer();
            customer.Cpf = Cpf;
            customer.Nome = Nome;
            customer.Senha = Senha;
            customer.Codigo = Codigo;
            customer.DataNascimento = DataNascimento;

            return customer;
        }
    }
}
