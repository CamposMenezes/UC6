using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoEstacionamento.Models
{
    internal class Vaga
    {
        public int Id { get; set; }
        public string Localizacao { get; set; }

        public string Tipo {  get; set; }
    }
}
