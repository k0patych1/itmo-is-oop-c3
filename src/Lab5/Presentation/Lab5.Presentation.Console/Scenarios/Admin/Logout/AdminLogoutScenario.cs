using Lab5.Application.Contracts.Users.Admins;

namespace Lab5.Presentation.Console.Scenarios.Admin.Logout;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLogoutScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Log out";

    public async Task Run()
    {
        await _adminService.LogOut();
    }
}