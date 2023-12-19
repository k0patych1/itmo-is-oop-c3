using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ReadMessageException : InvalidOperationException
{
    public ReadMessageException(string paramName)
        : base("You can't read a message you've read again" + paramName)
    {
    }

    public ReadMessageException()
    {
    }

    public ReadMessageException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}