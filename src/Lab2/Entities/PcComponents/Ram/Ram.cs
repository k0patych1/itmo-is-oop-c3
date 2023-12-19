using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;

public class Ram : PcComponentBase
{
    public Ram(
        string name,
        int amountOfAvailableMemorySize,
        RamFormFactor formFactor,
        DddrStandardVersion dddrStandardVersion,
        int powerConsumption,
        JedecProfile jedecProfile,
        IReadOnlyCollection<XmpProfile> availableXmpProfiles)
        : base(name)
    {
        if (amountOfAvailableMemorySize <= 0)
            throw new NegativeArgumentException(nameof(amountOfAvailableMemorySize));
        if (powerConsumption < 0)
            throw new NegativeArgumentException(nameof(powerConsumption));

        AmountOfAvailableMemorySize = amountOfAvailableMemorySize;
        FormFactor = formFactor;
        DdrStandardVersion = dddrStandardVersion;
        PowerConsumption = powerConsumption;
        JedecProfile = jedecProfile;
        AvailableXmpProfiles = availableXmpProfiles;
    }

    public int AmountOfAvailableMemorySize { get; }
    public RamFormFactor FormFactor { get; }
    public DddrStandardVersion DdrStandardVersion { get; }
    public int PowerConsumption { get; }
    public JedecProfile JedecProfile { get; }
    public IReadOnlyCollection<XmpProfile> AvailableXmpProfiles { get; }
}