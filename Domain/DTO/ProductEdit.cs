using Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class ProductEdit : ProductInclude
    {
        [Required(ErrorMessage = "O código deve ser enviado para efetuar a alteração.")]
        public long Codigo { get; set; }

        public ProductEdit()
        {

        }

        public new Product ToProduct()
        {
            Product product = new Product();
            product.Valor = Valor;
            product.Codigo = Codigo;
            product.Descricao = Descricao;
            product.CodigoBarras = CodigoBarras;

            return product;
        }
    }
}
