namespace OrderSystem.Models
{
    public class Nakladnaya
    {
        public int Id_nakladnaya { get; set; }
        public int Id_Order { get; set; }
        public Order order { get; set; }
        public int Id_product { get; set; }
        public Product product { get; set; }
        public int Amount { get; set; }
        public decimal Summa { get; set; }

    }
}
