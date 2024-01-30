namespace Lab5.Application.Models.Transactions;

public record Transaction(long Id, TransactionType Type,  long UserId, DateTime Date, decimal Amount);