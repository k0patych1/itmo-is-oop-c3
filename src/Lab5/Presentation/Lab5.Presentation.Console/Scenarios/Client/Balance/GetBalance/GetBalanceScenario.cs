using Lab5.Application.Contracts.Users.Clients;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Client.Balance.GetBalance;

public class GetBalanceScenario : IScenario
{
    private readonly IClientService _clientService;

    public GetBalanceScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Get balance";

    public async Task Run()
    {
        decimal? balance = await _clientService.GetBalance();

        if (balance is null) AnsiConsole.WriteLine("Something went wrong. Try again later");

        AnsiConsole.WriteLine($"Your balance is {balance}");
        AnsiConsole.Ask<string>("Ok");
    }
}