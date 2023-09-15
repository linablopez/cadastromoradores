using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Register
{
    public class RegisterPredioViewModel
    {
        [StringLength(200, ErrorMessage = "O campo Nome do Prédio deve ter no máximo 200 caracteres.")]
        public string NomePredio { get; set; }

        [StringLength(200, ErrorMessage = "O campo Rua deve ter no máximo 200 caracteres.")]
        public string Rua { get; set; }

        public int? Numero { get; set; }

        [StringLength(100, ErrorMessage = "O campo Bairro deve ter no máximo 100 caracteres.")]
        public string Bairro { get; set; }

        [StringLength(100, ErrorMessage = "O campo Cidade deve ter no máximo 100 caracteres.")]
        public string Cidade { get; set; }

        [StringLength(50, ErrorMessage = "O campo Estado deve ter no máximo 50 caracteres.")]
        public string Estado { get; set; }

        [StringLength(50, ErrorMessage = "O campo País deve ter no máximo 50 caracteres.")]
        public string Pais { get; set; }

        [StringLength(20, ErrorMessage = "O campo CEP deve ter no máximo 20 caracteres.")]
        public string CEP { get; set; }

        public DateTime? DataConstrucao { get; set; }

        public int? NumAndares { get; set; }
    }
}
