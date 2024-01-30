using Lab5.Application.Contracts.Users.Clients;
using Lab5.Application.Models.Clients;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Client.Login;

public class LoginScenario : IScenario
{
    private readonly IClientService _clientService;

    public LoginScenario(IClientService clientService)
    {
        _clientService = clientService;
    }

    public string Name => "Login";

    public async Task Run()
    {
        string username = AnsiConsole.Ask<string>("Enter your username : ");
        string password = AnsiConsole.Ask<string>("Enter your password : ");

        LoginResult result = await _clientService.Login(username, password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NameNotFound => "User not found",
            LoginResult.WrongPassword => "Wrong password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}