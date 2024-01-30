using Lab5.Application.Models.Clients;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Contracts.Users.Admins;

public interface IAdminService
{
    ValueTask<LoginResult> Login(string password);

    Task<IEnumerable<Transaction>> GetAllTransactions();

    Task LogOut();
}