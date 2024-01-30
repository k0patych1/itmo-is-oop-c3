using Lab5.Application.Extensions;
using Lab5.Infrastructure.DataAccess.Extensions;
using Lab5.Presentation.Console;
using Lab5.Presentation.Console.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace TerminalConsoleApp;

public static class Program
{
    public static async Task Main()
    {
        var collection = new ServiceCollection();

        collection
            .AddApplication()
            .AddInfrastructureDataAccess(configuration =>
            {
                configuration.Host = "localhost";
                configuration.Port = 5432;
                configuration.Username = "postgres";
                configuration.Password = "postgres";
                configuration.Database = "postgres";
                configuration.SslMode = "Prefer";
            })
            .AddPresentationConsole();

        ServiceProvider provider = collection.BuildServiceProvider();
        using IServiceScope scope = provider.CreateScope();

        scope.UseInfrastructureDataAccess();

        ScenarioRunner scenarioRunner = scope.ServiceProvider
            .GetRequiredService<ScenarioRunner>();

        while (true)
        {
            await scenarioRunner.Run();
            AnsiConsole.Clear();
        }
    }
}