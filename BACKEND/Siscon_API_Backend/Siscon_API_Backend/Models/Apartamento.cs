namespace Siscon_API_Backend.Models
{
    public class Apartamento
    {
        public long Id { get; set; }
        public int? NumeroApto { get; set; }
        public int? Andar { get; set; }
        public long? PredioId { get; set; }

        public Predio Predio { get; set; }
    }
}
