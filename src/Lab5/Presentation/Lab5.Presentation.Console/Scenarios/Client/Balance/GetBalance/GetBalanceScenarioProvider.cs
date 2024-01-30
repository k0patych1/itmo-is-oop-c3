using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Contracts.Users.Clients;

namespace Lab5.Presentation.Console.Scenarios.Client.Balance.GetBalance;

public class GetBalanceScenarioProvider : IScenarioProvider
{
    private readonly IClientService _service;
    private readonly ICurrentUserService _currentUser;

    public GetBalanceScenarioProvider(
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

        scenario = new GetBalanceScenario(_service);
        return true;
    }
}