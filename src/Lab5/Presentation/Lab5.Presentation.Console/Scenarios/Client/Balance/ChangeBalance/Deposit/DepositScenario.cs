using Lab5.Application.Contracts.Users.Clients;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Client.Balance.ChangeBalance.Deposit;

public class DepositScenario : IScenario
{
    private readonly IClientService _clientService;

    public DepositScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Deposit";

    public async Task Run()
    {
        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to deposit : ");

        if (amount < 0)
        {
            AnsiConsole.WriteLine("Amount cannot be negative");
            AnsiConsole.Ask<string>("Ok");
            return;
        }

        decimal? newBalance = await _clientService.ChangeBalance(amount);

        if (newBalance is null) AnsiConsole.WriteLine("Something went wrong. Try again later");

        AnsiConsole.WriteLine($"Deposited {amount}");
        AnsiConsole.WriteLine($"New balance is {newBalance}");
        AnsiConsole.Ask<string>("Ok");
    }
}