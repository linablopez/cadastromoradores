using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Register
{
    public class RegisterUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo Username é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Username deve ter no máximo 100 caracteres.")]
        public string LoginNome { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(int.MaxValue, ErrorMessage = "O campo Senha deve ter no máximo 2.147.483.647 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Nome do Usuário é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo Nome do Usuário deve ter no máximo 200 caracteres.")]
        public string NomeUsuario { get; set; }
    }
}
