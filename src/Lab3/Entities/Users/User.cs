using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User : IUser
{
    private readonly List<UserViewMessage> _messages;

    public User(ImportanceLevel interestingImportanceLevel)
    {
        _messages = new List<UserViewMessage>();
        InterestingImportanceLevel = interestingImportanceLevel;
    }

    public ImportanceLevel InterestingImportanceLevel { get; }

    public void GetMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        var userViewMessage = new UserViewMessage(message);
        _messages.Add(userViewMessage);
    }

    public bool IsReadMessage(int indexOfMessage)
    {
        return _messages[indexOfMessage - 1].IsRead;
    }

    public void ReadMessage(Message indexOfMessage)
    {
        throw new NotImplementedException();
    }

    public void ReadMessage(int indexOfMessage)
    {
        _messages[indexOfMessage - 1].Read();
    }
}