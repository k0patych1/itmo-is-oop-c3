using Lab5.Application.Models.Clients;

namespace Lab5.Application.Contracts.Users;

public interface ICurrentUserService
{
    Client? Client { get; }

    bool IsAdminLoggedIn { get; }
}