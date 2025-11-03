using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrodeUsuario.Models
{
    internal class Produto
    {
        public int id { get; set; }

        public string? Nome { get; set; }

        public Decimal? Preço { get; set; }

        public DateOnly Vencimento { get; set; }
    }
}
