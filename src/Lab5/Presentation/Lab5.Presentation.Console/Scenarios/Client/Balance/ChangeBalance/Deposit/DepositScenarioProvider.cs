using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Contracts.Users.Clients;

namespace Lab5.Presentation.Console.Scenarios.Client.Balance.ChangeBalance.Deposit;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly IClientService _service;
    private readonly ICurrentUserService _currentUser;

    public DepositScenarioProvider(
        IClientService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Client is null)
        {
            scenario = null;
            return false;
        }

        scenario = new DepositScenario(_service);
        return true;
    }
}