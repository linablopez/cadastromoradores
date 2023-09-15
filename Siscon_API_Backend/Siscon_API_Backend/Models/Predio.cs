namespace Siscon_API_Backend.Models
{
    public class Predio
    {
        public long Id { get; set; }
        public string NomePredio { get; set; }
        public string Rua { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public DateTime? DataConstrucao { get; set; }
        public int? NumAndares { get; set; }
    }
}
