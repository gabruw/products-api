using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class ProductInclude
    {
        [Required(ErrorMessage = "O campo 'Código de Barras' não pode ser nulo.")]
        [MaxLength(255, ErrorMessage = "O campo 'Código de Barras' deve conter no máximo 255 caracters.")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "O campo 'Descrição' não pode ser nulo.")]
        [MaxLength(255, ErrorMessage = "O campo 'Descrição' deve conter no máximo 255 caracters.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo 'Valor' não pode ser nulo.")]
        public double Valor { get; set; }

        public ProductInclude()
        {

        }
    }
}
