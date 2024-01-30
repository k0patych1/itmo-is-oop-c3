using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AdminPasswordRepository : IAdminPasswordRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminPasswordRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async ValueTask<string?> GetAdminPassword()
    {
        const string sql =
            """
            select password
            from admin_password;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        bool isRead = await reader.ReadAsync();
        return !isRead ? null : reader.GetString(0);
    }
}