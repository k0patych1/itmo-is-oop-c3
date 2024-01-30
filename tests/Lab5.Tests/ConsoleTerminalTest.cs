using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Clients;
using Lab5.Application.Users;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ConsoleTerminalTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public ConsoleTerminalTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Theory]
    [InlineData(1000, 100)]
    [InlineData(10000, 500)]
    public async void ChangeBalanceTest(decimal startBalance, decimal withdrawAmount)
    {
        var mockClients = new Mock<IClientRepository>();
        var currentClient = new Client(1, "ruslan", "123", startBalance);

        mockClients.Setup(client => client.FindClientByName("ruslan")).ReturnsAsync(currentClient);
        mockClients.Setup(client => client.ChangeMoney("ruslan", It.IsAny<decimal>()))
            .ReturnsAsync((string name, decimal amount) =>
            {
                decimal newMoney = amount + currentClient.Money;
                currentClient = currentClient with { Money = newMoney };
                return currentClient.Money;
            });

        var clientManager = new CurrentUserManager();

        var mockTransactions = new Mock<ITransactionRepository>();

        var clientService = new ClientService(mockClients.Object, clientManager, mockTransactions.Object);

        clientService.Register("ruslan", "123").AsTask().Wait();
        clientService.Login("ruslan", "123").AsTask().Wait();

        decimal? newMoney = await clientService.ChangeBalance(-withdrawAmount);

        Assert.Equal(startBalance - withdrawAmount, currentClient.Money);
        Assert.Equal(startBalance - withdrawAmount, newMoney);
    }
}