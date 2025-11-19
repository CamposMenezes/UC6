using Microsoft.EntityFrameworkCore;
using NovoEstacionamento.Models;

namespace NovoEstacionamento.Data
{
    // Cozinheiro: "DbContext é a classe principal do Entity Framework Core
    // que gerencia a conexão com o banco de dados
    // e é usada para consultar e salvar dados."
    class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
    }
}
