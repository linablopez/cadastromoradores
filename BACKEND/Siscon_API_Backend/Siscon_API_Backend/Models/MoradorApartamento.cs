namespace Siscon_API_Backend.Models
{
    public class MoradorApartamento
    {
        public long Id { get; set; }
        public long? MoradorId { get; set; }
        public long? ApartamentoId { get; set; }

        public Morador Morador { get; set; }
        public Apartamento Apartamento { get; set; }
    }
}
