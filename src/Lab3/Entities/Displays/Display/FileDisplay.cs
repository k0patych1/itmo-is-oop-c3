using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.Display;

public class FileDisplay : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public FileDisplay(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver ?? throw new ArgumentNullException(nameof(displayDriver));
    }

    private Message? Message { get; set; }

    public void GetMessage(Message message)
    {
        Message = message;
    }

    public void ShowMessage(ConsoleColor consoleColor)
    {
        if (Message is null) throw new NoReceivedMessageException("Display have no message to show");

        _displayDriver.Cache(Message);

        Message = null;
    }
}