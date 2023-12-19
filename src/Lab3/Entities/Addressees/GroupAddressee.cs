using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class GroupAddressee : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _recipients;

    public GroupAddressee(IReadOnlyCollection<IAddressee> recipients)
    {
        _recipients = recipients;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        foreach (IAddressee recipient in _recipients)
        {
            recipient.ReceiveMessage(message);
        }
    }
}