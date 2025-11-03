using CadastroVeiculo.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroVeiculo.Presention
{
    internal class ConsoleUI
    {
        private VeiculoController _veiculocontroller;

        public ConsoleUI (VeiculoController veiculocontroller)
        {
            _veiculocontroller = veiculocontroller;
        }

        public void MenuPrincipal()
        {
            bool sair = false;
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("==== Menu Principal ====");
                Console.WriteLine("1. Gerenciar Veículos");
                Console.WriteLine("2.");
                Console.WriteLine("0. Sair");

                string? opcao = Console.ReadLine();

                if (opcao == "1")
                {
                    MenuVeiculos();
                }
                else if (opcao == "2")
                {
                    Console.WriteLine("Não implementado");
                    Console.ReadKey();
                }
                else if (opcao == "0")
                {
                    sair = true;
                }
            }
        }

        void MenuVeiculos()
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine("==== Gerenciar Veiculos ====");
                Console.WriteLine("1. Listar veículos");
                Console.WriteLine("2. Detalhes de um veículo");
                Console.WriteLine("3. Cadastrar veículo");
                Console.WriteLine("5. Remover veículo");
                Console.WriteLine("0. Voltar");

                string? opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _veiculocontroller.ListarVeiculos();
                        break;
                    case "2":
                        _veiculocontroller.DetalhesVeiculo();
                        break;
                    case "3":
                      _veiculocontroller.AdicionarVeiculo();
                        break;
                    case "5":
                     _veiculocontroller.RemoverVeiculo();
                        break;
                    case "0":
                        voltar = true;
                        break;
                }
            }
        }
    }
}
