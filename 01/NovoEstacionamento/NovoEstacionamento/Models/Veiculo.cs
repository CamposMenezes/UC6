using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovoEstacionamento.Models
{
    internal class Veiculo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string? Cores { get; set; }

        // PROPRIEDADE DE NAVEGAÇÃO
        public Cliente Cliente { get; set; }
    }
}
