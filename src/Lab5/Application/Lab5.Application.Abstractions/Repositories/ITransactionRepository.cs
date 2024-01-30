using System.Collections.ObjectModel;
using Lab5.Application.Models.Transactions;

namespace Lab5.Application.Abstractions.Repositories;

public interface ITransactionRepository
{
    ValueTask<ReadOnlyCollection<Transaction>> GetAllTransactions();

    Task AddTransaction(TransactionType type, long userId, DateTime dateTime, decimal amount);
}