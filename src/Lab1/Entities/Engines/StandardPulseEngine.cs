using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public class StandardPulseEngine : PulseEngineBase
{
    public StandardPulseEngine()
        : base(CPulseEngineSpeed, CStandardPulseEngineFuelConsumption)
    {
    }

    private static int CPulseEngineSpeed => 28000;

    private static int CStandardPulseEngineFuelConsumption => 50;

    public override double CountTime(double distance)
    {
        if (distance < 0)
            throw new NegativeArgumentException(nameof(distance));

        return distance / Speed;
    }
}