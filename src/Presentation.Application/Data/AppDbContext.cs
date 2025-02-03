using Microsoft.EntityFrameworkCore;
using XPEDesafioFinal.Entities;

namespace XPEDesafioFinal.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
