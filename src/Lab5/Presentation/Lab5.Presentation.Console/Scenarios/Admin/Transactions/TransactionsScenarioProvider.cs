using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Contracts.Users.Admins;

namespace Lab5.Presentation.Console.Scenarios.Admin.Transactions;

public class TransactionsScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;

    public TransactionsScenarioProvider(
        IAdminService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (!_currentUser.IsAdminLoggedIn)
        {
            scenario = null;
            return false;
        }

        scenario = new TransactionsScenario(_service);
        return true;
    }
}