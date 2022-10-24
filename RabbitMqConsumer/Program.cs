using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMqClient;

namespace RabbitMqConsumer;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {

                var appsettings = "appsettings.json";

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(appsettings)
                    .Build();

                services.AddRabbitMQ(configuration);

                services.AddScoped<ITesteRabbitMq, TesteRabbitMq>();

                var serviceProvider = services.BuildServiceProvider();
                var testeRabbitMq = serviceProvider.GetService<ITesteRabbitMq>();
                testeRabbitMq?.Run();

            });
}