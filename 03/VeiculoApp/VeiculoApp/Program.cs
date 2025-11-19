using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeiculoApp.Controllers;
using VeiculoApp.Data;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string connectionString = "Server=(localdb)\\mssqllocaldb;Database=VeiculosAppDb;Trusted_Connection=True;";

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddTransient<VeiculosController>();
    })
    .Build();

var veiculosController = host.Services.GetRequiredService<VeiculosController>();

MenuVeiculos();

void MenuVeiculos()
{
    Console.Clear();
    Console.WriteLine("=== Menu de Veículos ===");
    Console.WriteLine("1. Adicionar Veículo");
    Console.WriteLine("2. Listar Veículos");
    Console.WriteLine("3. Remover Veículo");
    Console.WriteLine("0. Sair");

    Console.Write("Escolha uma opção: ");
    var opcao = Console.ReadLine();

    switch(opcao)
    {
        case "1":
            veiculosController.Adicionar();
            break;
        case "2":
            veiculosController.Listar();
            break;
        case "3":
            veiculosController.Remover();
            break;
        case "0":
            Environment.Exit(0);
            break;
    }
}