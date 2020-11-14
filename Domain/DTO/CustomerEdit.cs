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
    }
}
