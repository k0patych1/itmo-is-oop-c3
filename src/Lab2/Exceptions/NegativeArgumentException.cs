using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativeArgumentException : ArgumentException
{
    public NegativeArgumentException(string paramName)
        : base("The value cannot be less than 0", paramName)
    {
    }

    public NegativeArgumentException()
    {
    }

    public NegativeArgumentException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}