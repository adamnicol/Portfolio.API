using Microsoft.EntityFrameworkCore;
using Portfolio.API.Data.Entities;

namespace Portfolio.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=Portfolio;Integrated Security=True;TrustServerCertificate=True");
            }
        }

        public DbSet<User> Users { get; set; }
    }
}
