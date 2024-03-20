namespace OrderSystem.Models
{
    public class Order
    {
        public int Id_Order { get; set; }
        public int Id_Client { get; set; }
        public Client client { get; set; }
        public DateTime Date_order { get; set; }
        public int Id_employee { get; set; }
        public Employees employee { get; set; }
        public List<Nakladnaya> Nakladnayas { get; set; } = new List<Nakladnaya>();
    }
}
