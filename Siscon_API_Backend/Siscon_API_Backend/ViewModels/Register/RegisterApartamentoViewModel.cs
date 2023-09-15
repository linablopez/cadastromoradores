using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Register
{
    public class RegisterApartamentoViewModel
    {
        [Required(ErrorMessage = "O campo Número do Apartamento é obrigatório.")]
        public int? NumeroApto { get; set; }

        [Required(ErrorMessage = "O campo Andar é obrigatório.")]
        public int? Andar { get; set; }

        [Required(ErrorMessage = "O campo ID do Prédio é obrigatório.")]
        public long? PredioId { get; set; }
    }
}
