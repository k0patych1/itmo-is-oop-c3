using System.Collections.ObjectModel;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Transactions;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public TransactionRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async ValueTask<ReadOnlyCollection<Transaction>> GetAllTransactions()
    {
        const string sql =
            """
            select transaction_id, client_id, transaction_date, transaction_amount, transaction_type
            from transactions;
            """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using var command = new NpgsqlCommand(sql, connection);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        IList<Transaction> transactions = new List<Transaction>();

        while (await reader.ReadAsync())
        {
            long id = reader.GetInt64(0);
            long userId = reader.GetInt64(1);
            DateTime date = reader.GetDateTime(2);
            decimal amount = reader.GetDecimal(3);
            string type = reader.GetString(4);
            TransactionType transactionType = type switch
            {
                "deposit" => TransactionType.Deposit,
                "withdrawal" => TransactionType.Withdrawal,
                _ => throw new ArgumentOutOfRangeException(type),
            };

            transactions.Add(new Transaction(id, transactionType, userId, date, amount));
        }

        return transactions.AsReadOnly();
    }

    public async Task AddTransaction(TransactionType type, long userId, DateTime dateTime, decimal amount)
    {
        const string sql = """
                           insert into transactions (client_id, transaction_date, transaction_amount, transaction_type)
                           values (@clientId, @transactionDate, @amount, @transactionType);
                           """;

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(CancellationToken.None);

        await using NpgsqlCommand command = new NpgsqlCommand(sql, connection)
            .AddParameter("clientId", userId)
            .AddParameter("transactionDate", dateTime)
            .AddParameter("amount", amount)
            .AddParameter("transactionType", type);

        await command.ExecuteNonQueryAsync();
    }
}