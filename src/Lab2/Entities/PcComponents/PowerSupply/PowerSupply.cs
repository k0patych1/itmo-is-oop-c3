using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PowerSupply;

public class PowerSupply : PcComponentBase
{
    public PowerSupply(string name, int peakLoad)
        : base(name)
    {
        if (peakLoad < 0) throw new NegativeArgumentException(nameof(peakLoad));

        PeakLoad = peakLoad;
    }

    public int PeakLoad { get; }
}