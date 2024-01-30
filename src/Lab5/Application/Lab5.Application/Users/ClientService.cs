using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Users.Clients;
using Lab5.Application.Models.Admins;
using Lab5.Application.Models.Clients;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Users;

public class ClientService : IClientService
{
    private readonly IClientRepository _repository;

    private readonly ITransactionRepository _transactionRepository;

    private readonly CurrentUserManager _currentUserManager;

    public ClientService(
        IClientRepository repository,
        CurrentUserManager currentUserManager,
        ITransactionRepository transactionRepository)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
        _transactionRepository = transactionRepository;
    }

    public async ValueTask<LoginResult> Login(string username, string password)
    {
        Client? client = await _repository.FindClientByName(username);

        if (client is null)
            return LoginResult.NameNotFound;

        if (client.Password != password)
            return LoginResult.WrongPassword;

        _currentUserManager.Client = client;
        return LoginResult.Success;
    }

    public async ValueTask<RegisterResult> Register(string name, string password)
    {
        Client? client = await _repository.FindClientByName(name);

        if (client is not null)
            return RegisterResult.AlreadyExists;

        _currentUserManager.Client = await _repository.AddClient(name, password);

        return RegisterResult.Success;
    }

    public ValueTask<decimal?> GetBalance()
    {
        if (_currentUserManager.Client != null)
            return _repository.GetMoney(_currentUserManager.Client.Name);
        throw new UnauthorizedAccessException("You are not logged in");
    }

    public async ValueTask<decimal?> ChangeBalance(decimal amount)
    {
        TransactionType transactionType = amount > 0 ? TransactionType.Deposit : TransactionType.Withdrawal;

        if (_currentUserManager.Client is null)
            throw new UnauthorizedAccessException("Unexpected error : you haven't authorized");

        await _transactionRepository.AddTransaction(
            transactionType,
            _currentUserManager.Client.Id,
            DateTime.Now,
            decimal.Abs(amount));

        return await _repository.ChangeMoney(_currentUserManager.Client.Name, amount);
    }

    public Task LogOut()
    {
        _currentUserManager.Client = null;
        return Task.CompletedTask;
    }
}