using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscon_API_Backend.Models;

public class ApartamentoMap : IEntityTypeConfiguration<Apartamento>
{
    public void Configure(EntityTypeBuilder<Apartamento> builder)
    {
        builder.ToTable("apartamento");

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(x => x.NumeroApto)
               .HasColumnName("numero_apto");

        builder.Property(x => x.Andar)
               .HasColumnName("andar");

        builder.Property(x => x.PredioId)
               .HasColumnName("predio_id");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Predio)
               .WithMany()
               .HasForeignKey(x => x.PredioId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
