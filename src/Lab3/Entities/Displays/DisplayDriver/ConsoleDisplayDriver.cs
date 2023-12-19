using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays.DisplayDriver;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private readonly StreamWriter _file;

    public ConsoleDisplayDriver(StreamWriter file)
    {
        _file = file;
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void Cache(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _file.WriteLine(message.Title);
        _file.WriteLine(message.Body);
    }
}