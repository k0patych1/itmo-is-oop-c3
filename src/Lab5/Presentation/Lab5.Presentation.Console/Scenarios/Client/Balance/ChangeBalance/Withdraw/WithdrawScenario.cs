using Lab5.Application.Contracts.Users.Clients;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Client.Balance.ChangeBalance.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IClientService _clientService;

    public WithdrawScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Withdraw";

    public async Task Run()
    {
        decimal? currentBalance = await _clientService.GetBalance();

        if (currentBalance is null) AnsiConsole.WriteLine("Something went wrong. Try again later");

        decimal amount = AnsiConsole.Ask<decimal>("Enter amount to withdraw : ");

        if (amount < 0)
        {
            AnsiConsole.WriteLine("Amount cannot be negative");
            AnsiConsole.Ask<string>("Ok");
            return;
        }

        if (amount > currentBalance)
        {
            AnsiConsole.WriteLine("Amount cannot be greater than current balance");
            AnsiConsole.Ask<string>("Ok");
            return;
        }

        decimal? newBalance = await _clientService.ChangeBalance(-amount);

        if (newBalance is null) AnsiConsole.WriteLine("Something went wrong. Try again later");

        AnsiConsole.WriteLine($"Withdrawn {amount}");
        AnsiConsole.WriteLine($"New balance is {newBalance}");
        AnsiConsole.Ask<string>("Ok");
    }
}