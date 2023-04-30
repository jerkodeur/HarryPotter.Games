using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Prépare le moteur d'injection de dépendances et récupère les différentes données d'entrée de configuration,
// (appSettings, variables d'environnement, argument de console...)
// Configure la gestion des logs
// Utilise les paramêtres par défault
using var host = Host.CreateDefaultBuilder(args).UseEnvironment("production").Build();
var configuration = host.Services.GetRequiredService<IConfiguration>();

var connectionString = configuration.GetConnectionString("ConnexionTest");
var data = configuration["test"] ;

Console.WriteLine(connectionString);
Console.WriteLine(data);

host.Run();
