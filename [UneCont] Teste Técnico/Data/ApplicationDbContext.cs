using _UneCont__Teste_Técnico.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace _UneCont__Teste_Técnico.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotaFiscal>()
                .HasIndex(nf => nf.NumeroNota)
                .IsUnique();

            modelBuilder.Entity<NotaFiscal>()
                .Property(nf => nf.ValorTotal)
                .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }
    }
}
