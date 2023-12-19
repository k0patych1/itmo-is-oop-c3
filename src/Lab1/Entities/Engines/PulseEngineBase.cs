using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

public abstract class PulseEngineBase
{
    protected PulseEngineBase(double speed, double fuelConsumption)
    {
        if (speed < 0)
            throw new NegativeArgumentException(nameof(speed));

        if (fuelConsumption < 0)
            throw new NegativeArgumentException(nameof(fuelConsumption));

        Speed = speed;
        FuelConsumptionPerUnitTime = fuelConsumption;
    }

    protected double Speed { get; }

    private double FuelConsumptionPerUnitTime { get; }

    public double CountFullFuelConsumption(double time)
    {
        if (time < 0)
            throw new NegativeArgumentException(nameof(time));

        return time * FuelConsumptionPerUnitTime;
    }

    public abstract double CountTime(double distance);
}