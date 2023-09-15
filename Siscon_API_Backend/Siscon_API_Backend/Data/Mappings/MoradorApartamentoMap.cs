using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Siscon_API_Backend.Models
{
    public class MoradorApartamentoMap : IEntityTypeConfiguration<MoradorApartamento>
    {
        public void Configure(EntityTypeBuilder<MoradorApartamento> builder)
        {
            builder.ToTable("morador_apartamento");

            builder.Property(x => x.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(x => x.MoradorId)
                   .HasColumnName("morador_id");

            builder.Property(x => x.ApartamentoId)
                   .HasColumnName("apartamento_id");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Morador)
                   .WithMany()
                   .HasForeignKey(x => x.MoradorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Apartamento)
                   .WithMany()
                   .HasForeignKey(x => x.ApartamentoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
