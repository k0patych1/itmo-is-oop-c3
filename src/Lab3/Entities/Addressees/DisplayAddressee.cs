using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public class DisplayAddressee : IAddressee
{
    private readonly IDisplay _consoleDisplay;

    public DisplayAddressee(IDisplay consoleDisplay)
    {
        _consoleDisplay = consoleDisplay ?? throw new ArgumentNullException(nameof(consoleDisplay));
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _consoleDisplay.GetMessage(message);
    }
}