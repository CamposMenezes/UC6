using Microsoft.EntityFrameworkCore;
using VeiculoApp.Models;

namespace VeiculoApp.Data
{
    internal class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}

