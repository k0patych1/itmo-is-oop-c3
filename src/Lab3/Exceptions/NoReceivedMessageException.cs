using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NoReceivedMessageException : Exception
{
    public NoReceivedMessageException(string message)
        : base(message)
    {
    }

    public NoReceivedMessageException()
    {
    }

    public NoReceivedMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}