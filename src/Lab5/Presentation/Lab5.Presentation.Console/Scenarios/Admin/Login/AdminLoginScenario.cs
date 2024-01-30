using System.Security.Authentication;
using Lab5.Application.Contracts.Users.Admins;
using Lab5.Application.Models.Clients;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Admin.Login;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as admin";

    public async Task Run()
    {
        string password = AnsiConsole.Ask<string>("Enter your password : ");

        LoginResult result = await _adminService.Login(password);

        if (result is LoginResult.WrongPassword)
        {
            throw new AuthenticationException("Wrong password");
        }

        AnsiConsole.WriteLine("You are logged in as admin");
        AnsiConsole.Ask<string>("Ok");
    }
}