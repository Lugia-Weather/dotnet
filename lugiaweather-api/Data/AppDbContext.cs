using lugiaweather_api.Models;
using Microsoft.EntityFrameworkCore;

namespace lugiaweather_api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<DispositivoIot> DispositivosIot { get; set; }
    public DbSet<Leitura> Leituras { get; set; }
    public DbSet<Alerta> Alertas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Endereco>()
            .Property(e => e.DataCriacao)
            .HasDefaultValueSql("SYSTIMESTAMP")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<DispositivoIot>()
            .Property(d => d.DataCriacao)
            .HasDefaultValueSql("SYSTIMESTAMP")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Leitura>()
            .Property(d => d.DataCriacao)
            .HasDefaultValueSql("SYSTIMESTAMP")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Alerta>()
            .Property(d => d.DataCriacao)
            .HasDefaultValueSql("SYSTIMESTAMP")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<DispositivoIot>()
            .Property(d => d.Status)
            .HasConversion<string>(); 

        modelBuilder.Entity<Leitura>()
            .Property(l => l.StatusNivel)
            .HasConversion<string>();

        modelBuilder.Entity<Alerta>()
            .Property(a => a.Tipo)
            .HasConversion<string>();
    }
}