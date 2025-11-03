using CadastroVeiculo.Controllers;
using CadastroVeiculo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args).ConfigureServices((context, services) =>
{
    string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ConsoleSimpleDb;Trusted_Connection=True;";

    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

    services.AddTransient<VeiculoController>();
})
    .Build();

var veiculoController = host.Services.GetRequiredService<VeiculoController>();
