
using CadastrodeUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastrodeUsuario.Data
{
    internal class AppDbContext  : DbContext
    {

      public AppDbContext(DbContextOptions<AppDbContext> options ) : base  (options) 
        { 
        
        }
       
      

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produto { get; set; }

    }
     




}
 