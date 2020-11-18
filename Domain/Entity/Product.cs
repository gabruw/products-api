namespace Domain.Entity
{
    public class Product
    {
        public long Codigo { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public virtual Order Product_Order { get; set; }

        public Product()
        {

        }
    }
}
