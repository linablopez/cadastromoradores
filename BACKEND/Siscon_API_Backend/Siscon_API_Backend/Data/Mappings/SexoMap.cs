using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscon_API_Backend.Models;

public class SexoMap : IEntityTypeConfiguration<Sexo>
{
    public void Configure(EntityTypeBuilder<Sexo> builder)
    {
        builder.ToTable("sexo");

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(x => x.Descricao)
               .HasColumnName("descricao")
               .HasMaxLength(20);

        builder.HasKey(x => x.Id);
    }
}
