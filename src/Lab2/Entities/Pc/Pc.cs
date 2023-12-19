using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;

public class Pc
{
    public Pc(
        Motherboard motherboard,
        Cpu cpu,
        Bios bios,
        CpuCoolingSystem cpuCoolingSystem,
        Collection<Ram> ramSticks,
        XmpProfile? xmpProfile,
        Videocard? videocard,
        Collection<Ssd> ssds,
        Collection<Hdd> hdds,
        PcCase pcCase,
        PowerSupply powerSupply,
        WiFiAdapter? wiFiAdapter)
    {
        Motherboard = motherboard;
        Cpu = cpu;
        Bios = bios;
        CpuCoolingSystem = cpuCoolingSystem;
        RamSticks = ramSticks;
        XmpProfile = xmpProfile;
        Videocard = videocard;
        Ssds = ssds;
        Hdds = hdds;
        PcCase = pcCase;
        PowerSupply = powerSupply;
        WiFiAdapter = wiFiAdapter;
    }

    public Motherboard Motherboard { get; }
    public Cpu Cpu { get; }
    public Bios Bios { get; }
    public CpuCoolingSystem CpuCoolingSystem { get; }
    public Collection<Ram> RamSticks { get; }
    public XmpProfile? XmpProfile { get; }
    public Videocard? Videocard { get; }
    public Collection<Ssd> Ssds { get; }
    public Collection<Hdd> Hdds { get; }
    public PcCase PcCase { get; }
    public PowerSupply PowerSupply { get; }
    public WiFiAdapter? WiFiAdapter { get; }
}