using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Register
{
    public class RegisterMoradorApartamentoViewModel
    {
        [Required(ErrorMessage = "O campo MoradorId é obrigatório.")]
        public long? MoradorId { get; set; }

        [Required(ErrorMessage = "O campo ApartamentoId é obrigatório.")]
        public long? ApartamentoId { get; set; }
    }
}
