namespace OrderSystem.Models
{
    public class Employees 
    {
        public int Id_employee { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
