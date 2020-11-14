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

        [Required(ErrorMessage = "O valor 'CPF' não pode ser nulo.")]
        [MinLength(11, ErrorMessage = "O valor 'CPF' deve conter 11 caracters.")]
        [MaxLength(11, ErrorMessage = "O valor 'CPF' deve conter 11 caracters.")]
        public long Cpf { get; set; }

        [CollectionLength(1, ErrorMessage = "Deve haver ao menos 1 produto para que o pedido seja efetuado.")]
        public  ICollection<Product> Products { get; set; }

        public OrderInclude()
        {

        }
    }
}
