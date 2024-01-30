using Lab5.Application.Contracts.Users.Clients;
using Lab5.Application.Models.Admins;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Client.Register;

public class RegisterScenario : IScenario
{
    private readonly IClientService _clientService;

    public RegisterScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Register";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username : ");
        string password = AnsiConsole.Ask<string>("Enter your password : ");

        RegisterResult result = await _clientService.Register(username, password);

        string message = result switch
        {
            RegisterResult.Success => "Successful register",
            RegisterResult.AlreadyExists => "Username is already taken",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}