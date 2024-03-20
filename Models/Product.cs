using System.Runtime.CompilerServices;

namespace OrderSystem.Models
{
    public class Product
    {
        public int Id_product { get; set; }
        public string Nazvanie { get; set; }
        public int Id_PC { get; set; }
        public Product_category category {  get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<Nakladnaya> Nakladnayas { get; set; } = new List<Nakladnaya>();    
    }
}
