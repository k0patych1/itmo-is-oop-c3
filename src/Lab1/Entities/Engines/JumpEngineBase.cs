using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class JumpEngineBase
{
    protected JumpEngineBase(double jumpRange, double fuelConsumption)
    {
        if (jumpRange < 0)
            throw new NegativeArgumentException(nameof(jumpRange));

        if (fuelConsumption < 0)
            throw new NegativeArgumentException(nameof(jumpRange));

        JumpRange = jumpRange;
        FuelConsumption = fuelConsumption;
    }

    public double JumpRange { get; }
    public double FuelConsumption { get; }
}