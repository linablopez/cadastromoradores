using System.ComponentModel.DataAnnotations;

namespace Siscon_API_Backend.ViewModels.Editor
{
    public class EditorUsuarioViewModel
    {

        [Required(ErrorMessage = "O campo Nome do Usuário é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo Nome do Usuário deve ter no máximo 200 caracteres.")]
        public string NomeUsuario { get; set; }

    }
}
