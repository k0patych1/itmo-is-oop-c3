using Lab5.Application.Contracts.Users;
using Lab5.Application.Models.Clients;

namespace Lab5.Application.Users;

public class CurrentUserManager : ICurrentUserService
{
    public Client? Client { get; set; }

    public bool IsAdminLoggedIn { get; set; }
}