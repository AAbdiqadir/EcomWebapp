namespace Ecommerce_website.Models
{
    public class Cart
    {

        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
