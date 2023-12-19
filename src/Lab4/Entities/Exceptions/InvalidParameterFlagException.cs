using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;

public class InvalidParameterFlagException : ArgumentException
{
    public InvalidParameterFlagException(string message)
        : base(message)
    {
    }

    public InvalidParameterFlagException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public InvalidParameterFlagException()
    {
    }
}