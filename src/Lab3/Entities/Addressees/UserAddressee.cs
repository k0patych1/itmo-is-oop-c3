using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class UserAddressee : IAddressee
{
    private readonly IUser _recipient;

    public UserAddressee(IUser recipient)
    {
        _recipient = recipient;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _recipient.GetMessage(message);
    }
}