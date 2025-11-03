using CadastrodeUsuario.Data;
using CadastrodeUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrodeUsuario.Controller
{
    internal class ProdutoController
    {
        private AppDbContext _context;


        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            Console.Clear();

            Console.WriteLine("Nome do produto: ");
            string nomeProduto = Console.ReadLine();

            Console.WriteLine("Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Data de Vencimento: ");
            DateOnly vencimento = DateOnly.Parse(Console.ReadLine());

            var novoProduto = new Produto()
            {
                Nome = nomeProduto,
                Preço = preco,
                Vencimento = vencimento

            };

            _context.Produto.Add(novoProduto);
            _context.SaveChanges();

            Console.WriteLine("Produto adicionado com sucesso! \nAperte qualquer tecla para finalizar.");
            Console.ReadKey();
        }

        public void Listar()
        {
            Console.Clear();
            var produto = _context.Produto.ToList();

            if (!produto.Any())
            {
                Console.WriteLine("Nenhum produto cadastrado!");
            }
            else
            {
                foreach (var Produto in produto)
                {
                    Console.WriteLine($"Nome: {Produto.Nome} | Preço: {Produto.Preço} | Vencimento: {Produto.Vencimento}");
                }

            }

            Console.WriteLine("\nPressione qualquer tecla para voltar");
            Console.ReadKey();
        }

        public void Detalhes()
        {

            Console.Clear();
            Console.WriteLine("====Detalhes do Produto====");


            Console.WriteLine("Digite o ID do produto: ");
            var idProduto = int.Parse(Console.ReadLine());


            var produto = _context.Produto.FirstOrDefault(user => user.id == idProduto);


            if (produto == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
            }


            else
            {
                Console.WriteLine("==== Dados do Produto ====");
                Console.WriteLine($"Nome: {produto.Nome}");
                Console.WriteLine($"Preço: {produto.Preço}");
                Console.WriteLine($"Vencimento: {produto.Vencimento}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public void Remover()
        {
            Console.Clear();
            Console.WriteLine("==== Remover Produto ====");
            Console.WriteLine("Digite o ID do produto");
            var idProduto = int.Parse(Console.ReadLine());

            // Buscar usuário no banco de dados
            var produtoParaDeletar = _context.Produto.FirstOrDefault(user => user.id == idProduto);

            // Se não enontrar, avisar o Usuário
            if (produtoParaDeletar == null)
            {
                Console.WriteLine("\nProduto não encontrado!");
                Console.ReadKey();
                return;

            }

            _context.Produto.Remove(produtoParaDeletar);
            _context.SaveChanges();

            Console.WriteLine("\nProduto removido com sucesso!");
            Console.ReadKey();

        }
    }
}
