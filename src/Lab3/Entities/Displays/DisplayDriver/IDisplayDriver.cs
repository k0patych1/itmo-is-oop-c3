using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;

public interface IDisplayDriver
{
    public void Clear();

    public void SetColor(ConsoleColor color);

    public void Cache(Message message);
}