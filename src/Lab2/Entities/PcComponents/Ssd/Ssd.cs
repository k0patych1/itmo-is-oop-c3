using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ssd;

public class Ssd : PcComponentBase
{
    public Ssd(
        string name,
        ConnectionOption connectionOption,
        int capacity,
        int maximumOperatingSpeed,
        int powerConsumption)
        : base(name)
    {
        if (capacity < 0) throw new NegativeArgumentException(nameof(capacity));
        if (maximumOperatingSpeed < 0) throw new NegativeArgumentException(nameof(maximumOperatingSpeed));
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        ConnectionOption = connectionOption;
        Capacity = capacity;
        MaximumOperatingSpeed = maximumOperatingSpeed;
        PowerConsumption = powerConsumption;
    }

    public ConnectionOption ConnectionOption { get; }
    public int Capacity { get; }
    public int MaximumOperatingSpeed { get; }
    public int PowerConsumption { get; }
}