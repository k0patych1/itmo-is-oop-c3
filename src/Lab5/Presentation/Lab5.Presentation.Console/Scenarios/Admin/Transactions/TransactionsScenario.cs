using Lab5.Application.Contracts.Users.Admins;
using Lab5.Application.Models.Transactions;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin.Transactions;

public class TransactionsScenario : IScenario
{
    private readonly IAdminService _adminService;

    public TransactionsScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Look at transactions";

    public async Task Run()
    {
        IEnumerable<Transaction> transactions = await _adminService.GetAllTransactions();
        AnsiConsole.WriteLine("Transactions:");
        foreach (Transaction transaction in transactions)
        {
            AnsiConsole.WriteLine($"Transaction ID: {transaction.Id}");
            AnsiConsole.WriteLine($"Type: {transaction.Type}");
            AnsiConsole.WriteLine($"User ID: {transaction.UserId}");
            AnsiConsole.WriteLine($"Date: {transaction.Date}");
            AnsiConsole.WriteLine($"Amount: {transaction.Amount}");
            AnsiConsole.WriteLine();
        }

        AnsiConsole.Ask<string>("Ok");
    }
}