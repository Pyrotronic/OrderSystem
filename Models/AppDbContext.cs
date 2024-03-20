using Microsoft.EntityFrameworkCore;



namespace OrderSystem.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb);Port=5432;Database=OrderSystem;Trusted_Connection=True;");
            return new AppDbContext(optionsBuilder.Options);
        }

        public DbSet<Employees> Employees { get; set; }

        public DbSet<Client> Client { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>().HasKey(e => e.Id_employee);
            modelBuilder.Entity<Client>().HasKey(c => c.id_Client);
            modelBuilder.Entity<Product_category>().HasKey(pc => pc.Id_PC);
            modelBuilder.Entity<Product>().HasKey(p => p.Id_product);
            modelBuilder.Entity<Order>().HasKey(o => o.Id_Order);
            modelBuilder.Entity<Nakladnaya>().HasKey(n => n.Id_nakladnaya);
            modelBuilder.Entity<Product>().HasOne(p => p.category).WithMany(pc => pc.Products).HasForeignKey(p => p.Id_PC);
            modelBuilder.Entity<Order>().HasOne(o => o.client).WithMany(c => c.Orders).HasForeignKey(o => o.Id_Client);
            modelBuilder.Entity<Order>().HasOne(o => o.employee).WithMany(e => e.Orders).HasForeignKey(o => o.Id_employee);
            modelBuilder.Entity<Nakladnaya>().HasOne(n => n.order).WithMany(o => o.Nakladnayas).HasForeignKey(n => n.Id_Order);
            modelBuilder.Entity<Nakladnaya>().HasOne(n => n.product).WithMany(p => p.Nakladnayas).HasForeignKey(o => o.Id_product);
        }
        public DbSet<Product_category> Product_category { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }
        public DbSet<Nakladnaya> Nakladnaya { get; set; }
    }
}
