using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;

public class CommandExecuteException : Exception
{
    public CommandExecuteException(string message)
        : base(message)
    {
    }

    public CommandExecuteException()
    {
    }

    public CommandExecuteException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}