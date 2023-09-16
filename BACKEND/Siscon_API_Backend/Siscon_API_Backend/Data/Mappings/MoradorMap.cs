using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Siscon_API_Backend.Models
{
    public class MoradorMap : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.ToTable("morador");

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.NumeroDocumento)
                   .HasColumnName("numerodocumento")
                   .HasMaxLength(20);

            builder.Property(x => x.TipoDocumentoId)
                   .HasColumnName("tipodocumento_id");

            builder.Property(x => x.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(200);

            builder.Property(x => x.DataNascimento)
                   .HasColumnName("datanascimento");

            builder.Property(x => x.Idade)
                   .HasColumnName("idade");

            builder.Property(x => x.SexoId)
                   .HasColumnName("sexo_id");

            builder.Property(x => x.Telefone)
                   .HasColumnName("telefone")
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .HasColumnName("email")
                   .HasMaxLength(100);

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Sexo)
                   .WithMany()
                   .HasForeignKey(x => x.SexoId);

            builder.HasOne(x => x.TipoDocumento)
                   .WithMany()
                   .HasForeignKey(x => x.TipoDocumentoId);
        }
    }
}
