using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.Display;

public interface IDisplay
{
    public void GetMessage(Message message);

    public void ShowMessage(ConsoleColor consoleColor);
}