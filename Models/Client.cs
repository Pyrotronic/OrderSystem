    using OrderSystem.Models;

    namespace OrderSystem.Models
    {
        public class Client
        {
            public int id_Client { get; set; }
            public string Surname { get; set; } = null!;
            public string Name { get; set; } = null!;
            public string phone { get; set; } = null!;
            public string Address { get; set; } = null!;
            public string bank { get; set; } = null!;
            public string card_number { get; set; } = null!;
            public List<Order> Orders { get; set; } = new List<Order>();
        }
    }