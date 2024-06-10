using ApiGestao.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiGestao.Banco
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Nenhuma configuração adicional necessária aqui
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure seus modelos aqui, se necessário
        }
    }
}
