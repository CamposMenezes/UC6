using EstacionamentoConsole.Controllers;
using EstacionamentoConsole.Models;
using EstacionamentoConsole.Controllers;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)

    .ConfigureServices((context, services) =>

    {

        services.AddDbContext<EstacionamentoDbContext>(opt =>

            opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EstacionamentoDB;" +
            "Trusted_Connection=True;TrustServerCertificate=True;"));
        services.AddTransient<ClienteController>();

    })

    .Build();

var clientesController = host.Services.GetRequiredService<ClienteController>();
bool sair = false;



while (!sair)
{

Console.WriteLine("==== Sistema de Estacionamento =====");
Console.WriteLine("1. Listar Clientes");
Console.WriteLine("2. Adicionar Cliente");
Console.WriteLine("3. (A FAZER) Gerenciar Veiculos");
Console.WriteLine("4. (A FAZER) Gerenciar Vagas");
Console.WriteLine("5. Ver detalhes do Cliente.");
Console.WriteLine("0. Sair");
string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            clientesController.ListarClientes();
            break;
        case "2":
            clientesController.AdicionarCliente();
            break;
        case "3":
            Console.WriteLine("Chamou o Gerenciar Veiculos");
            break;
        case "4":
            Console.WriteLine("Chamou o Gerenciar Vagas");
            break;
        case "5":
        clientesController.VerDetalhesCliente();
            break;
        case "0":
            sair = true;
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente. ");
            Console.ReadKey();
            break;
    }
}

Console.WriteLine("Encerrando Sistema. Até Logo!");
