using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;

public class CommandParseException : ArgumentException
{
    public CommandParseException(string message)
        : base(message)
    {
    }

    public CommandParseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public CommandParseException()
    {
    }
}