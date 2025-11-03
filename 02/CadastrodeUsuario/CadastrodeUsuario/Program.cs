using CadastrodeUsuario.Controller;
using CadastrodeUsuario.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics.Eventing.Reader;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UsuariosDB;Trusted_Connection=True;"));

        services.AddTransient<UsuarioController>();
    }).Build();

var usuarioController = host.Services
    .GetRequiredService<UsuarioController>();

MenuPrincipal();


void MenuPrincipal()
{
    bool sair = false;
    while (!sair)
    {
        Console.Clear();
        Console.WriteLine("==== Menu Principal ====");
        Console.WriteLine("1. Gerenciar Usuários");
        Console.WriteLine("2. Gerenciar Produtos");
        Console.WriteLine("0. Sair");

        string? opcao =  Console.ReadLine();

        if (opcao == "1")
        {
            MenuUsuarios();
        }
        else if (opcao == "2")
        {
            Console.WriteLine("Gerenciamento não implementado!");
            Console.ReadKey();
        }
        else if (opcao == "0")

        {
            sair = true;
        }
    }
}

void MenuUsuarios()
{
   bool voltar = false; 
    while (!voltar)
    {
        Console.Clear();
        Console.WriteLine("==== Gerenciar Usuários ====");
        Console.WriteLine("1. Listar usuários");
        Console.WriteLine("2. Detalhes de um Usuário");
        Console.WriteLine("3. Cadastrar Usuários");
        Console.WriteLine("4. Atualizar Usuários");
        Console.WriteLine("5. Remover um Usuário por ID");
        Console.WriteLine("0. Voltar");

        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                usuarioController.Listar();
                break;
            case "2":
                usuarioController.Detalhes();
                break;
            case "3":
                usuarioController.Adicionar();
                break;
            case "":
                usuarioController.AtualizarUsuario();
                break;
            case "5":
                usuarioController.Remover();
                break;
            case "0":
                voltar = true;
                break;
        }
    }
}