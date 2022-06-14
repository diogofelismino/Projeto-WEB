using escolaNC.Modelo;
using escolaNC.Modelos;
using Microsoft.EntityFrameworkCore;

namespace escolaNC.Data
{
    public class EscolaContext : DbContext
    {

        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options){}

        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Servico> SERVICOS { get; set; }
        public DbSet<Contratados> SERVICOS_CONTRATADOS { get; set; }
        public DbSet<Login> USER_LOGIN { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Servico>().Property(e => e.id)
            .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            modelBuilder.Entity<Contratados>().Property(e => e.id_servicos_contratados)
            .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
           
        }


    }
}
