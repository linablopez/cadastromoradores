using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siscon_API_Backend.Models;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuario");

        builder.Property(x => x.Id)
               .HasColumnName("id")
               .IsRequired();

        builder.Property(x => x.LoginNome)
               .HasColumnName("usuario")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Senha)
               .HasColumnName("senha")
               .IsRequired()
               .HasColumnType("varchar(max)");

        builder.Property(x => x.NomeUsuario)
               .HasColumnName("nome_usuario")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.DataCriacao)
               .HasColumnName("datacriacao");

        builder.HasKey(x => x.Id);
    }
}
