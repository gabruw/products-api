using Domain.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class CustomerInclude
    {
        [Required(ErrorMessage = "O campo 'CPF' não pode ser nulo.")]
        [MinLength(14, ErrorMessage = "O campo 'CPF' deve conter 14 caracters.")]
        [MaxLength(14, ErrorMessage = "O campo 'CPF' deve conter 14 caracters.")]
        public string Cpf { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O campo 'Senha' não pode ser nulo.")]
        [MinLength(6, ErrorMessage = "O campo 'Senha' deve conter pelo menos 6 caracters.")]
        [MaxLength(40, ErrorMessage = "O campo 'Senha' deve conter no máximo 40 caracters.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' não pode ser nulo.")]
        [MaxLength(255, ErrorMessage = "O campo 'Nome' deve conter no máximo 255 caracters.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Required(ErrorMessage = "O campo 'Data de Nascimento' não pode ser nulo.")]
        public DateTime DataNascimento { get; set; }

        public CustomerInclude()
        {

        }

        public Customer ToCostumer()
        {
            Customer customer = new Customer();
            customer.Cpf = Cpf;
            customer.Nome = Nome;
            customer.Senha = Senha;
            customer.DataNascimento = DataNascimento;

            return customer;
        }
    }
}
