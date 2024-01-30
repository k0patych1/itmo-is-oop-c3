using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Clients;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public ClientRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async ValueTask<Client?> FindClientByName(string name)
    {
        const string sql =
            """
            select client_id, client_name, client_password, money
            from clients
            where client_name = :clientName;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("clientName", name);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        bool isRead = await reader.ReadAsync();

        if (!isRead) return null;

        return new Client(
            Id: reader.GetInt64(0),
            Name: reader.GetString(1),
            Password: reader.GetString(2),
            Money: reader.GetDecimal(3));
    }

    public async ValueTask<Client?> AddClient(string name, string password)
    {
        const string sql =
            """
            insert into clients (client_name, client_password, money)
            values (:name, :password, 0)
            returning client_id, client_name, client_password, money;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("name", name)
            .AddParameter("password", password);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        bool isRead = await reader.ReadAsync();
        if (!isRead) return null;

        return new Client(
            Id: reader.GetInt64(0),
            Name: reader.GetString(1),
            Password: reader.GetString(2),
            Money: reader.GetDecimal(3));
    }

    public async ValueTask<decimal?> GetMoney(string name)
    {
        const string sql =
            """
            select money
            from clients
            where client_name = :name;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using NpgsqlCommand clientCommand = new NpgsqlCommand(sql, connection)
            .AddParameter("name", name);

        await using NpgsqlDataReader reader = await clientCommand.ExecuteReaderAsync();

        bool isRead = await reader.ReadAsync();

        if (!isRead) return null;

        return reader.GetDecimal(0);
    }

    public async ValueTask<decimal?> ChangeMoney(string name, decimal amount)
    {
        const string sql = """
                           update clients
                           set money = money + :amount
                           where client_name = :name
                           returning money;
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("amount", amount)
            .AddParameter("name", name);

        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        bool isRead = await reader.ReadAsync();

        if (!isRead) return null;

        return reader.GetDecimal(0);
    }
}