using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users.Admins;
using Lab5.Application.Models.Clients;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Users;

public class AdminService : IAdminService
{
    private readonly ITransactionRepository _transactionRepository;

    private readonly IAdminPasswordRepository _adminPasswordRepository;

    private readonly CurrentUserManager _currentUserManager;

    public AdminService(
        ITransactionRepository transactionRepository,
        IAdminPasswordRepository adminPasswordRepository,
        CurrentUserManager currentUserManager)
    {
        _transactionRepository = transactionRepository;
        _adminPasswordRepository = adminPasswordRepository;
        _currentUserManager = currentUserManager;
    }

    public async ValueTask<LoginResult> Login(string password)
    {
        if (await _adminPasswordRepository.GetAdminPassword() != password)
            return LoginResult.WrongPassword;
        _currentUserManager.IsAdminLoggedIn = true;
        return LoginResult.Success;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        return await _transactionRepository.GetAllTransactions();
    }

    public Task LogOut()
    {
        _currentUserManager.IsAdminLoggedIn = false;
        return Task.CompletedTask;
    }
}