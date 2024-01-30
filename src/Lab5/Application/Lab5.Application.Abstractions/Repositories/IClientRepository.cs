using Lab5.Application.Models.Clients;

namespace Lab5.Application.Abstractions.Repositories;

public interface IClientRepository
{
    ValueTask<Client?> FindClientByName(string name);

    ValueTask<Client?> AddClient(string name, string password);

    ValueTask<decimal?> GetMoney(string name);

    ValueTask<decimal?> ChangeMoney(string name, decimal amount);
}