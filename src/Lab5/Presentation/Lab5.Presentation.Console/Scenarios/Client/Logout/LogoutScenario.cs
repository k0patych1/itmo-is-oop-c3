using Lab5.Application.Contracts.Users.Clients;

namespace Lab5.Presentation.Console.Scenarios.Client.Logout;

public class LogoutScenario : IScenario
{
    private readonly IClientService _clientService;

    public LogoutScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Log out";

    public Task Run()
    {
        _clientService.LogOut();
        return Task.CompletedTask;
    }
}