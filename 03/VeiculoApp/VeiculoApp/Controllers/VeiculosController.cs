using VeiculoApp.Data;
using VeiculoApp.Models;

namespace VeiculoApp.Controllers
{
    internal class VeiculosController
    {
        private AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Veículo ===");
            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? string.Empty;

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? string.Empty;

            var veiculo = new Veiculo
            {
                Marca = marca,
                Modelo = modelo
            };

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public void Listar()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Veículos ===");
            var veiculos = _context.Veiculos.ToList();
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"ID: {veiculo.Id} | Marca: {veiculo.Marca} | Modelo: {veiculo.Modelo}");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public void Remover()
        {
            Console.Clear();
            Console.WriteLine("=== Remover Veículo ===");
            Console.Write("ID do Veículo a ser removido: ");
            var veiculo = _context.Veiculos.Find(int.Parse(Console.ReadLine()));
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                _context.SaveChanges();
                Console.WriteLine("Veículo removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado.");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
