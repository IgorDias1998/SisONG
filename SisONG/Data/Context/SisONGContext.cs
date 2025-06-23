using Microsoft.EntityFrameworkCore;
using SisONG.Models;

namespace SisONG.Data.Context
{
    public class SisONGContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<ProdutoInsumo> ProdutosInsumos { get; set; }
        public DbSet<TransacaoFinanceira> TransacoesFinanceiras { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<PontoColeta> PontosDeColeta { get; set; }
        public DbSet<EventoVoluntario> EventoVoluntarios { get; set; }  
        public DbSet<HistoricoUso> HistoricosDeUso { get; set; }

        public SisONGContext(DbContextOptions<SisONGContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventoVoluntario>()
                .HasKey(ev => new { ev.EventoId, ev.VoluntarioId });

            modelBuilder.Entity<EventoVoluntario>()
                .HasOne(ev => ev.Evento)
                .WithMany(e => e.EventoVoluntarios)
                .HasForeignKey(ev => ev.EventoId);

            modelBuilder.Entity<EventoVoluntario>()
                .HasOne(ev => ev.Voluntario)
                .WithMany(v => v.EventoVoluntarios)
                .HasForeignKey(ev => ev.VoluntarioId);
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
