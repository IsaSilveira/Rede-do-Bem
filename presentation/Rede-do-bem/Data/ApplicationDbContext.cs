using Microsoft.EntityFrameworkCore;
using Rede_do_bem.Models;

namespace Rede_do_bem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PerfilUsuario> PerfilUsuarios { get; set; }
    public DbSet<PerfilInstituicao> PerfilInstituicoes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Campanha> Campanhas { get; set; }
    public DbSet<Doacao> Doacoes { get; set; }
    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<Avaliacao> Avaliacoes { get; set; }
    public DbSet<Denuncia> Denuncias { get; set; }
    public DbSet<InstituicaoSalva> InstituicoesSalvas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();
           
    }

}
