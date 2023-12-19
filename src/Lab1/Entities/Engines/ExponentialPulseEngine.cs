using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class ExponentialPulseEngine : PulseEngineBase
{
    public ExponentialPulseEngine()
        : base(CPulseEngineSpeed, CExponentialPulseEngineFuelConsumption)
    {
    }

    private static int CPulseEngineSpeed => 28000;

    private static int CExponentialPulseEngineFuelConsumption => 1000;

    public override double CountTime(double distance)
    {
        if (distance < 0)
            throw new NegativeArgumentException(nameof(distance));

        return Math.Log(distance);
    }
}