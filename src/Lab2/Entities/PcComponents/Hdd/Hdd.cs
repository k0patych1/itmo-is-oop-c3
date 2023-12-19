using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Hdd;

public class Hdd : PcComponentBase
{
    public Hdd(string name, int capacity, int spindleSpeed, int powerConsumption)
        : base(name)
    {
        if (capacity < 0) throw new NegativeArgumentException(nameof(capacity));
        if (spindleSpeed < 0) throw new NegativeArgumentException(nameof(spindleSpeed));
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; }
    public int SpindleSpeed { get; }
    public int PowerConsumption { get; }
}