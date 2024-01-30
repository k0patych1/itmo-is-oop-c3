using Lab5.Presentation.Console.Scenarios.Admin.Login;
using Lab5.Presentation.Console.Scenarios.Admin.Logout;
using Lab5.Presentation.Console.Scenarios.Admin.Transactions;
using Lab5.Presentation.Console.Scenarios.Client.Balance.ChangeBalance.Deposit;
using Lab5.Presentation.Console.Scenarios.Client.Balance.ChangeBalance.Withdraw;
using Lab5.Presentation.Console.Scenarios.Client.Balance.GetBalance;
using Lab5.Presentation.Console.Scenarios.Client.Login;
using Lab5.Presentation.Console.Scenarios.Client.Logout;
using Lab5.Presentation.Console.Scenarios.Client.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegisterScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TransactionsScenarioProvider>();

        return collection;
    }
}