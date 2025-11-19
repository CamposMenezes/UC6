using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.Controller
{
    internal class UsuarioController
    {
        private AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            Console.Clear();
            #region Pedir_Dados
            Console.Write("Primeiro Nome: ");
            string primeiroNome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Data de Nascimento: ");
            DateOnly nascimento = DateOnly.Parse(Console.ReadLine());
            #endregion

            var novoUsuario = new Usuario()
            {
                DataNascimento = nascimento,
                PrimeiroNome = primeiroNome,
                Sobrenome = sobrenome
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine("Usuário Cadastrado");
            Console.ReadKey();
        }

        public void Listar()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count() == 0)
            {
                Console.WriteLine("Nenum usuário cadastrado!");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.PrimeiroNome}");
                }
            }

            Console.WriteLine("\nPressione qualquer telca para voltar.");
            Console.ReadKey();
        }

        public void Detalhes()
        {
            // Dizer onde estou
            Console.Clear();
            Console.WriteLine("==== Detalhes do Usuário ====");
            
            // Pedir o ID do usuário
            Console.Write("Digite o ID do usuário: ");
            var idUsuario = int.Parse(Console.ReadLine());

            // Buscar o usuário no banco de dados
            var usuario = _context.Usuarios
                .FirstOrDefault(user => user.Id == idUsuario);

            // Se não encontrar, avisar o usuário
            if (usuario == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
            }
            else // Se encontrar, mostrar os detalhes do usuário
            {
                Console.WriteLine("--- Dados do Usuário ---");
                Console.WriteLine($"ID: {usuario.Id}");
                Console.WriteLine($"Nome: {usuario.PrimeiroNome}");
                Console.WriteLine($"Sobrenome: {usuario.Sobrenome}");
                Console.WriteLine($"Nascimento: {usuario.DataNascimento}");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public void Remover()
        {
            Console.Clear();
            Console.WriteLine("==== Remover Usuário ====");
            Console.Write("Digite o ID do usuário: ");
            var idUsuario = int.Parse(Console.ReadLine());

            // Buscar o usuário no banco de dados
            var usuarioParaDeletar = _context.Usuarios
                .FirstOrDefault(user => user.Id == idUsuario);

            // Se não encontrar, avisar o usuário
            if(usuarioParaDeletar == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
                Console.ReadKey();
                return;
            }

            // Se encontrar, deletar o usuário
            _context.Usuarios.Remove(usuarioParaDeletar);
            _context.SaveChanges();

            Console.WriteLine("\nUsuário removido com sucesso!");
            Console.ReadKey();
        }

        public void AtualizarUsuario()
        {
            Console.Clear();
            Console.WriteLine("=== Atualizar Usuário ===");
            Console.Write("Digite o ID do usuário que deseja atualizar: ");
            var idUsuario = int.Parse(Console.ReadLine());

            var usuarioParaAtualizar = _context.Usuarios
                .FirstOrDefault(user => user.Id == idUsuario);

            if(usuarioParaAtualizar == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
                Console.ReadKey();
                return;
            }

            Console.Write("Novo Primeiro Nome: ");
            string primerioNome = Console.ReadLine() ?? "";

            Console.Write("Novo Sobrenome: ");
            string sobrenome = Console.ReadLine() ?? "";

            Console.Write("Nova Data de Nascimento: ");
            DateOnly dataNascimento = DateOnly.Parse(Console.ReadLine() ?? "");

            usuarioParaAtualizar.PrimeiroNome = primerioNome;
            usuarioParaAtualizar.Sobrenome = sobrenome;
            usuarioParaAtualizar.DataNascimento = dataNascimento;

            _context.Usuarios.Update(usuarioParaAtualizar);
            _context.SaveChanges();

            Console.WriteLine("\nUsuário atualizado com sucesso!");
            Console.ReadKey();
        }
    }
}
