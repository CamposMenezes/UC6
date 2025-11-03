using CadastrodeUsuario.Data;
using CadastrodeUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastrodeUsuario.Controller
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
            #region Pedir Dados
            Console.WriteLine("Primeiro nome: ");
            string primeironome = Console.ReadLine();

            Console.WriteLine("Segundo Nome: ");
            string sobrenome = Console.ReadLine();

            Console.WriteLine("Data de Nascimento: ");
            DateOnly nascimento = DateOnly.Parse(Console.ReadLine());
            #endregion
            var novoUsuario = new Usuario()
            {
                DataNascimento = nascimento,
                PrimeiroNome = primeironome,
                Sobrenome = sobrenome
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine("Usuário Cadastrado com sucesso! \nAperte qualquer tecla para finalizar.");
            Console.ReadKey();
        }


        public void Listar()
        {
            Console.Clear();
            var usuarios = _context.Usuarios.ToList();

            if (!usuarios.Any())
            {
                Console.WriteLine("Nenhum usuário cadastrado!");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.id} | Nome: {usuario.PrimeiroNome}");
                }

            }

            Console.WriteLine("\nPressione qualquer tecla para voltar");
            Console.ReadKey();
        }

         public void Detalhes ()
        {
            // Dizer onde estou
            Console.Clear();
            Console.WriteLine("====Detalhes do Usuário====");
            

            // Pedir o ID do usuário
            Console.WriteLine("Digite o ID do usuário: ");
            var idUsuario = int.Parse(Console.ReadLine());

            // Buscar usuário no banco de dados
            var usuario = _context.Usuarios.FirstOrDefault(user => user.id == idUsuario); 
            

            // Se não encontrar, avisar o usuário

            if (usuario == null)
            {
                Console.WriteLine("\nUsuário não encontrado!");
            }

            // Se econtrar, mostrar os detalhes do usuário
            else
            {
                Console.WriteLine("==== Dados do Usuário ====");
                Console.WriteLine($"ID: {usuario.id}");
                Console.WriteLine($"Nome: {usuario.PrimeiroNome}");
                Console.WriteLine($"Sobrenome: {usuario.Sobrenome}");
                Console.WriteLine($"Nascimento: {usuario.DataNascimento}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar.");
            Console.ReadKey();
        }

        public void Remover ()
        {
            Console.Clear();
            Console.WriteLine("==== Remover Usuário ====");
            Console.WriteLine("Digite o ID do usuário");
            var idUsuario = int.Parse (Console.ReadLine());

            // Buscar usuário no banco de dados
            var usuarioParaDeletar = _context.Usuarios.FirstOrDefault( user => user.id == idUsuario);

            // Se não enontrar, avisar o Usuário
            if (usuarioParaDeletar == null )
            {
                Console.WriteLine("\nUsuário não encontrado!");
                Console.ReadKey ();
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
            Console.WriteLine("==== Atualizar Usuario ====");
            Console.WriteLine("Digite o ID do usuário: ");
            var idInformado = int.Parse(Console.ReadLine());

            var usuarioParaAtualizar = _context.Usuarios.FirstOrDefault(u => u.id == idInformado);

            if (usuarioParaAtualizar == null)
            {
                Console.WriteLine("Usuário não encontrado!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"\nEditando usuário: {usuarioParaAtualizar.PrimeiroNome}");
            Console.WriteLine("Novo primeiro nome: ");
            string novoPrimeiroNome = Console.ReadLine() ?? "";
            Console.WriteLine("Novo Sobrenome: ");
            string novoSobrenome = Console.ReadLine() ?? "";
            Console.WriteLine("Nova Data de Nascimento (AAAA-MM-DD): ");
            DateOnly novaDataNascimento = DateOnly.Parse(Console.ReadLine() ?? "");

            usuarioParaAtualizar.PrimeiroNome = novoPrimeiroNome;
            usuarioParaAtualizar.Sobrenome = novoSobrenome;
            usuarioParaAtualizar.DataNascimento = novaDataNascimento;

            _context.Usuarios.Update(usuarioParaAtualizar);
            _context.SaveChanges();

            Console.WriteLine("\nUsuário atualizado com sucesso!");
            Console.ReadKey();

        }


    }

}

