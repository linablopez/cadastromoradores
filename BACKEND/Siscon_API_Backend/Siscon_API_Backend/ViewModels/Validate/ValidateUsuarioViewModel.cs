using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Validate
{
    public class ValidateUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo Username é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Username deve ter no máximo 100 caracteres.")]
        public string LoginNome { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(int.MaxValue, ErrorMessage = "O campo Senha deve ter no máximo 2.147.483.647 caracteres.")]
        public string Senha { get; set; }
    }
}
