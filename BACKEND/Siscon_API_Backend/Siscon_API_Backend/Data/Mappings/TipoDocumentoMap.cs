using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscon_API_Backend.Models;

public class TipoDocumentoMap : IEntityTypeConfiguration<TipoDocumento>
{
    public void Configure(EntityTypeBuilder<TipoDocumento> builder)
    {
        builder.ToTable("tipodocumento");

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(x => x.Descricao)
               .HasColumnName("descricao")
               .HasMaxLength(50);

        builder.HasKey(x => x.Id);
    }
}
