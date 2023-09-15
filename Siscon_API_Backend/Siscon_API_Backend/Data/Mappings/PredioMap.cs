using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscon_API_Backend.Models;

public class PredioMap : IEntityTypeConfiguration<Predio>
{
    public void Configure(EntityTypeBuilder<Predio> builder)
    {
        builder.ToTable("predio");

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(x => x.NomePredio)
               .HasColumnName("nome_predio")
               .HasMaxLength(200);

        builder.Property(x => x.Rua)
               .HasColumnName("rua")
               .HasMaxLength(200);

        builder.Property(x => x.Numero)
               .HasColumnName("numero");

        builder.Property(x => x.Bairro)
               .HasColumnName("bairro")
               .HasMaxLength(100);

        builder.Property(x => x.Cidade)
               .HasColumnName("cidade")
               .HasMaxLength(100);

        builder.Property(x => x.Estado)
               .HasColumnName("estado")
               .HasMaxLength(50);

        builder.Property(x => x.Pais)
               .HasColumnName("pais")
               .HasMaxLength(50);

        builder.Property(x => x.CEP)
               .HasColumnName("cep")
               .HasMaxLength(20);

        builder.Property(x => x.DataConstrucao)
               .HasColumnName("data_construcao");

        builder.Property(x => x.NumAndares)
               .HasColumnName("num_andares");

        builder.HasKey(x => x.Id);
    }
}
