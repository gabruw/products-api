using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class Login
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

        public Login()
        {

        }
    }
}
