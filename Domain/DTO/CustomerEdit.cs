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
            Customer costumer = new Customer();
            costumer.Cpf = Cpf;
            costumer.Nome = Nome;
            costumer.Senha = Senha;
            costumer.Codigo = Codigo;
            costumer.DataNascimento = DataNascimento;

            return costumer;
        }
    }
}
