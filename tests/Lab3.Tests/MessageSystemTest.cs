using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Telegram;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Moq;
using Serilog;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class MessageSystemTest
{
    [Fact]
    public void UserGetAndReadMessageTest()
    {
        var user = new User(ImportanceLevel.UnimportantAndNonUrgent);
        var userAddressee = new UserAddressee(user);
        var topic = new Topic("test", userAddressee);
        var message = new Message("i", "hate it", ImportanceLevel.ImportantAndUrgent);
        topic.SendMessage(message);
        Assert.False(user.IsReadMessage(1));
        user.ReadMessage(1);
        Assert.True(user.IsReadMessage(1));
        Assert.Throws<ReadMessageException>(() => user.ReadMessage(1));
    }

    [Fact]
    public void FilterMessageByImportanceLevelTest()
    {
        var userAddresseeMock = new Mock<IAddressee>();
        var filterAddressee = new FilterAddressee(userAddresseeMock.Object, ImportanceLevel.ImportantAndUrgent);

        var topic = new Topic("mock", filterAddressee);
        var message = new Message("i", "hate c# mocking", ImportanceLevel.UnimportantAndUrgent);
        topic.SendMessage(message);

        userAddresseeMock.Verify(a => a.ReceiveMessage(message), Times.Never);
    }

    [Fact]
    public void LoggingTest()
    {
        var logger = new Mock<ILogger>();
        var user = new User(ImportanceLevel.UnimportantAndNonUrgent);
        var loggingAddressee = new LoggingAddressee(new UserAddressee(user), logger.Object);

        var topic = new Topic("mock", loggingAddressee);
        var message = new Message("a", "b", ImportanceLevel.ImportantAndUrgent);
        topic.SendMessage(message);

        logger.Verify(l => l.Information($"Received message: {message}"), Times.Once);
    }

    [Fact]
    public void SendMessageToMessengerTest()
    {
        var logger = new Mock<ILogger>();
        var telegram = new Telegram(logger.Object);
        var loggingAddressee = new MessengerAddressee(new TelegramAdapter(telegram, 1));

        var topic = new Topic("mock", loggingAddressee);
        var message = new Message("a", "b", ImportanceLevel.ImportantAndUrgent);
        topic.SendMessage(message);

        logger.Verify(l => l.Information("[Telegram] " + message.Body), Times.Once);
    }
}