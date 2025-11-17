using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.MAUI.Models
{
    internal class Motorista
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Telefone { get; set; }
        public ICollection<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    }
}
