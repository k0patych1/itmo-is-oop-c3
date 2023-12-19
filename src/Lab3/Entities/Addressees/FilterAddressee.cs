using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class FilterAddressee : IAddressee
{
    private readonly IAddressee _addressee;

    private readonly ImportanceLevel _importanceLevelOfUser;

    public FilterAddressee(IAddressee addressee, ImportanceLevel importanceLevelOfUser)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _importanceLevelOfUser = importanceLevelOfUser;
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        if (message.ImportanceLevel >= _importanceLevelOfUser)
        {
            _addressee.ReceiveMessage(message);
        }
    }
}