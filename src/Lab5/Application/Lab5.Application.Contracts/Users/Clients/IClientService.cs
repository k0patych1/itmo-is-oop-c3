using Lab5.Application.Models.Admins;
using Lab5.Application.Models.Clients;

namespace Lab5.Application.Contracts.Users.Clients;

public interface IClientService
{
    ValueTask<LoginResult> Login(string username, string password);

    ValueTask<RegisterResult> Register(string name, string password);

    ValueTask<decimal?> GetBalance();

    ValueTask<decimal?> ChangeBalance(decimal amount);

    Task LogOut();
}