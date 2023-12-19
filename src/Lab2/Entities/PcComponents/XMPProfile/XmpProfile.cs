using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;

public class XmpProfile : PcComponentBase
{
    public XmpProfile(string name, Timings timings)
        : base(name)
    {
        Timings = timings;
    }

    public Timings Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}