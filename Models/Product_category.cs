namespace OrderSystem.Models
{
    public class Product_category
    {
        public int Id_PC { get; set; }
        public string Nazvanie { get; set; }
        public List<Product> Products { get; set;} = new List<Product>();
    }
}
