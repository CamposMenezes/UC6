using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovoEstacionamento.Models
{
    internal class Cliente
    {

        public int ID { get; set; }
        public string Nome { get; set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }

        public string cpf { get; set; }
        public string Telefone { get; set; }
        public string email { get; set; }

    }
}
