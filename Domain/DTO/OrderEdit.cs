using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class OrderEdit : OrderInclude
    {
        [Required(ErrorMessage = "O código deve ser enviado para efetuar a alteração.")]
        public long Codigo { get; set; }

        public OrderEdit()
        {

        }
    }
}
