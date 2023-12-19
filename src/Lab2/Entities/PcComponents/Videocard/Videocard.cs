using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Videocard;

public class Videocard : PcComponentBase
{
    public Videocard(
        string name,
        Dimensions dimensions,
        int videoMemoryAmount,
        PcieVersion pcieVersion,
        int chipFrequency,
        int powerConsumption)
        : base(name)
    {
        if (videoMemoryAmount < 0) throw new NegativeArgumentException(nameof(videoMemoryAmount));
        if (chipFrequency < 0) throw new NegativeArgumentException(nameof(chipFrequency));
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        Dimensions = dimensions;
        VideoMemoryAmount = videoMemoryAmount;
        PcieVersion = pcieVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimensions Dimensions { get; }
    public int VideoMemoryAmount { get; }
    public PcieVersion PcieVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
}