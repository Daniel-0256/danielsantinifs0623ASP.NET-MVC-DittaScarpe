using DittaScarpe.Models;
using Microsoft.EntityFrameworkCore;



public class DittaScarpeContext : DbContext
{
    public DittaScarpeContext(DbContextOptions<DittaScarpeContext> options) : base(options)
    {
    }

    public DbSet<Articolo> Articoli { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Articolo>(entity =>
         {
             // Imposta il tipo di colonna SQL, la precisione e la scala per la proprietà 'Prezzo'

             entity.Property(e => e.Prezzo).HasColumnType("decimal(18, 2)"); // Ad esempio, decimal(18, 2) è una scelta comune
                                                                             // Aggiungi qui altre configurazioni di modello se necessario
         });
    }
}


