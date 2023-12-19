using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _messenger.SendMessage(message);
    }
}