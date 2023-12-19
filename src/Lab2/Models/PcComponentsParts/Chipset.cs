using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

public class Chipset
{
    public Chipset(
        string name,
        int minAvailableMemoryFrequency,
        IReadOnlyCollection<XmpProfile> supportedXmpProfiles,
        bool isHasWifiModule)
    {
        if (minAvailableMemoryFrequency < 0) throw new NegativeArgumentException(nameof(minAvailableMemoryFrequency));

        Name = name;
        AvailableMemoryFrequencies = minAvailableMemoryFrequency;
        SupportedXmpProfiles = supportedXmpProfiles;
        IsHasWifiModule = isHasWifiModule;
    }

    public string Name { get; }
    public int AvailableMemoryFrequencies { get; }
    public IReadOnlyCollection<XmpProfile> SupportedXmpProfiles { get; }
    public bool IsHasWifiModule { get; }
}