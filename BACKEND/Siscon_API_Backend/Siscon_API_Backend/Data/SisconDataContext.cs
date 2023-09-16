using Microsoft.EntityFrameworkCore;
using Siscon_API_Backend.Models;

namespace Siscon_API_Backend.Data
{
    public class SisconDataContext: DbContext
    {
       public SisconDataContext(DbContextOptions<SisconDataContext> options)
        : base(options)
           {
           }

       public DbSet<Usuario> Usuarios { get; set; }
       public DbSet<Predio> Predios { get; set; }
       public DbSet<Sexo> Sexos { get; set; }
       public DbSet<TipoDocumento> TipoDocumentos { get; set; }
       public DbSet<Apartamento> Apartamentos { get; set; }
       public DbSet<Morador> Moradores { get; set; }
       public DbSet<MoradorApartamento> MoradoresApartamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.ApplyConfiguration(new UsuarioMap());
           modelBuilder.ApplyConfiguration(new PredioMap());
           modelBuilder.ApplyConfiguration(new SexoMap());
           modelBuilder.ApplyConfiguration(new TipoDocumentoMap());
           modelBuilder.ApplyConfiguration(new ApartamentoMap());
           modelBuilder.ApplyConfiguration(new MoradorMap());
           modelBuilder.ApplyConfiguration(new MoradorApartamentoMap());
        }
    }
}
