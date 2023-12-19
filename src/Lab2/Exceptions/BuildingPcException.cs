using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class BuildingPcException : Exception
{
    public BuildingPcException(string message)
        : base(message)
    {
    }

    public BuildingPcException()
    {
    }

    public BuildingPcException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}