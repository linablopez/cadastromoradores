namespace Siscon_API_Backend.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string LoginNome { get; set; }
        public string Senha { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
