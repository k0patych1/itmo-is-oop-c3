using System.Diagnostics.CodeAnalysis;
using Lab5.Application.Contracts.Users;
using Lab5.Application.Contracts.Users.Admins;

namespace Lab5.Presentation.Console.Scenarios.Admin.Logout;

public class AdminLogoutScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;

    public AdminLogoutScenarioProvider(
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

        scenario = new AdminLogoutScenario(_service);
        return true;
    }
}