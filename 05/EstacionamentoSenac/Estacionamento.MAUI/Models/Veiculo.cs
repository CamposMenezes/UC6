
namespace Estacionamento.MAUI.Models
{
    internal class Veiculo
    {
        public int id { get; set; }
        public string placa { get; set; }
        public string? Modelo { get; set; }
        public string? Cor { get; set; }
        public int MotoristaId { get; set; }

        public Motorista Motorista { get; set; }

    }
}
