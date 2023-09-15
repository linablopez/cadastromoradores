using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Editor
{
    public class EditorMoradorViewModel
    {
        [StringLength(20, ErrorMessage = "O campo Número do Documento deve ter no máximo 20 caracteres.")]
        public string NumeroDocumento { get; set; }

        public long? TipoDocumentoId { get; set; }

        [StringLength(200, ErrorMessage = "O campo Nome deve ter no máximo 200 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        public int? Idade { get; set; }

        public int? SexoId { get; set; }

        [StringLength(20, ErrorMessage = "O campo Telefone deve ter no máximo 20 caracteres.")]
        public string Telefone { get; set; }

        [StringLength(100, ErrorMessage = "O campo Email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O campo Email não é um endereço de email válido.")]
        public string Email { get; set; }
    }
}
