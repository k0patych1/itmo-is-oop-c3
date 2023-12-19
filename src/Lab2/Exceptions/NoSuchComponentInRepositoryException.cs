using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NoSuchComponentInRepositoryException : KeyNotFoundException
{
    public NoSuchComponentInRepositoryException(string message)
        : base(message)
    {
    }

    public NoSuchComponentInRepositoryException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }

    public NoSuchComponentInRepositoryException()
    {
    }
}