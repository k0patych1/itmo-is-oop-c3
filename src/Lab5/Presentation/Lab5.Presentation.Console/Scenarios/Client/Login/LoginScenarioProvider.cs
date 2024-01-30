using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Contracts.Users.Clients;

namespace Lab5.Presentation.Console.Scenarios.Client.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IClientService _service;
    private readonly ICurrentUserService _currentUser;

    public LoginScenarioProvider(
        IClientService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.Client is not null || _currentUser.IsAdminLoggedIn)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginScenario(_service);
        return true;
    }
}