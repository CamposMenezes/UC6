using CadastroVeiculo.Data;
using CadastroVeiculo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CadastroVeiculo.Controllers
{
    public class VeiculoController
    {
        private readonly AppDbContext _context;

        public VeiculoController (AppDbContext context)
        {
            _context = context;
        }

        public void AdicionarVeiculo()
        {
            Console.Clear();
            Console.WriteLine("==== Adicionar Novo Veiculo ====");

            Console.WriteLine("Modelo do veiculo: ");
                string nomeModelo = Console.ReadLine() ?? "";

            Console.WriteLine("Marca do veiculo: ");
            string marcaVeiculo = Console.ReadLine() ?? "";


            var novoVeiculo = new Veiculo
            {
                Marca = marcaVeiculo,
                Modelo = nomeModelo

            };

            _context.Veiculos.Add(novoVeiculo);
            _context.SaveChanges();

            Console.WriteLine("\nVeiculo adicionado com sucesso!");
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();

        }

        public void ListarVeiculos ()
        {
            Console.Clear();
            Console.WriteLine("==== Lista de Veiculos ====");

            var veiculos = _context.Veiculos.ToList();

            if (!veiculos.Any())
            {
                Console.WriteLine("Nenhum veiculo cadastrado.");
            }
            else
            {
               foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"Marca: {veiculo.Marca} | Modelo: {veiculo.Modelo}");
                }

            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey ();

        }
        public void DetalhesVeiculo ()
        {
            Console.Clear();
            Console.WriteLine("==== Detalhes do veiculo ====");
            Console.WriteLine("Digite o ID do veículo para ver os detalhes: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido!");
            }
            else
            {
                var veiculo = _context.Veiculos.FirstOrDefault(u => u.Id == id);
                if (veiculo == null)
                {
                    Console.WriteLine("\nVeiculo Não encontrado!");
                }
                else
                {
                    Console.WriteLine("\n==== Dados do veículo====");
                    Console.WriteLine($"ID: {veiculo.Id}");
                    Console.WriteLine($"Marca: {veiculo.Marca}");
                    Console.WriteLine($"Modelo: {veiculo.Modelo}");

                }
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu");
            Console.ReadKey (); 
        }

        public void AtualizarVeiculo ()
        {
            Console.Clear();
            Console.WriteLine("==== Atualizar veículo====");
            Console.WriteLine("Digite o ID do veículo que deseja atualizar: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var veiculoToUpdate = _context.Veiculos.FirstOrDefault(v => v.Id == id);
                if (veiculoToUpdate != null)
                {
                    Console.WriteLine($"\nEditando  veículo: {veiculoToUpdate.Modelo}.Deixe em branco para não alterar.");

                    Console.WriteLine($"Novo modelo do véiculo ({veiculoToUpdate.Modelo}): ");
                    string newNovoModelo = Console.ReadLine() ?? "";
                    if (string.IsNullOrEmpty(newNovoModelo))
                    {
                        veiculoToUpdate.Modelo = newNovoModelo;

                    }

                    _context.SaveChanges();
                    Console.WriteLine("\nVeículo atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine("\nVeiculo não encontrado");
                }

            }
            else
            {
                Console.WriteLine("\nID inválido");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey ();

            
        }

        public void RemoverVeiculo ()
        {
            Console.Clear();
            Console.WriteLine("==== Remover Veículo ====");
            Console.Write("Digite o ID do veículo que deseja remover: ");
            
            if (int.TryParse (Console.ReadLine(), out int id))
            {
                var veiculoToRemove = _context.Veiculos.FirstOrDefault( v => v.Id == id);
                if (veiculoToRemove != null)
                {
                    Console.WriteLine($"\nEncontrado: ID: {veiculoToRemove.Id} | Modelo: {veiculoToRemove.Modelo} {veiculoToRemove.Marca}");
                    Console.Write("Tem certeza que deseja remover este veículo? (S/N): ");
                    string confirmacao = Console.ReadLine() ?? "";

                    if (confirmacao.Equals("S", StringComparison.OrdinalIgnoreCase))
                    {
                        _context.Veiculos.Remove(veiculoToRemove);
                        _context.SaveChanges();
                        Console.WriteLine("\nVeículo removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nVeículo não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("\nID inválido!");

            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey ();
        }

       
    }
}
