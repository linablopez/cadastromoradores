using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Editor
{
    public class EditorUsuarioSenhaViewModel
    {
        [Required(ErrorMessage = "O campo Nome do Usuário é obrigatório.")]
        public string senha { get; set; }
    }
}
