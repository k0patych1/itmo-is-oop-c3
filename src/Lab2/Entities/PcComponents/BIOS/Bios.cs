using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;

public class Bios : PcComponentBase
{
    public Bios(string name, BiosType type, BiosVersion version, IReadOnlyCollection<string> supportedProcessors)
        : base(name)
    {
        Type = type;
        Version = version;
        SupportedProcessors = supportedProcessors;
    }

    public BiosType Type { get; }
    public BiosVersion Version { get; }
    public IReadOnlyCollection<string> SupportedProcessors { get; }
}