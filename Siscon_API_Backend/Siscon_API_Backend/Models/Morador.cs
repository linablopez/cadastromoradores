namespace Siscon_API_Backend.Models
{
    public class Morador
    {
        public long Id { get; set; }
        public string NumeroDocumento { get; set; }
        public long? TipoDocumentoId { get; set; }
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Idade { get; set; }
        public int? SexoId { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public virtual Sexo Sexo { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}
