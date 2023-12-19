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

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

public class AllPcComponentRepository
{
    public AllPcComponentRepository()
    {
        CpuRepository = new PcComponentRepository<Cpu>();
        BiosRepository = new PcComponentRepository<Bios>();
        CpuCoolingSystemRepository = new PcComponentRepository<CpuCoolingSystem>();
        HddRepository = new PcComponentRepository<Hdd>();
        MotherboardRepository = new PcComponentRepository<Motherboard>();
        PcCaseRepository = new PcComponentRepository<PcCase>();
        PowerSupplyRepository = new PcComponentRepository<PowerSupply>();
        RamRepository = new PcComponentRepository<Ram>();
        SsdRepository = new PcComponentRepository<Ssd>();
        VideocardRepository = new PcComponentRepository<Videocard>();
        WiFiRepository = new PcComponentRepository<WiFiAdapter>();
        XmpProfileRepository = new PcComponentRepository<XmpProfile>();
    }

    public AllPcComponentRepository(
        IPcComponentRepository<Cpu> cpuRepository,
        IPcComponentRepository<Bios> biosRepository,
        IPcComponentRepository<CpuCoolingSystem> cpuCoolingSystemRepository,
        IPcComponentRepository<Hdd> hddRepository,
        IPcComponentRepository<Motherboard> motherboardRepository,
        IPcComponentRepository<PcCase> pcCaseRepository,
        IPcComponentRepository<PowerSupply> powerSupplyRepository,
        IPcComponentRepository<Ram> ramRepository,
        IPcComponentRepository<Ssd> ssdRepository,
        IPcComponentRepository<Videocard> videocardRepository,
        IPcComponentRepository<WiFiAdapter> wiFiRepository,
        IPcComponentRepository<XmpProfile> xmpProfileRepository)
    {
        CpuRepository = cpuRepository;
        BiosRepository = biosRepository;
        CpuCoolingSystemRepository = cpuCoolingSystemRepository;
        HddRepository = hddRepository;
        MotherboardRepository = motherboardRepository;
        PcCaseRepository = pcCaseRepository;
        PowerSupplyRepository = powerSupplyRepository;
        RamRepository = ramRepository;
        SsdRepository = ssdRepository;
        VideocardRepository = videocardRepository;
        WiFiRepository = wiFiRepository;
        XmpProfileRepository = xmpProfileRepository;
    }

    public IPcComponentRepository<Cpu> CpuRepository { get; }
    public IPcComponentRepository<Bios> BiosRepository { get; }
    public IPcComponentRepository<CpuCoolingSystem> CpuCoolingSystemRepository { get; }
    public IPcComponentRepository<Hdd> HddRepository { get; }
    public IPcComponentRepository<Motherboard> MotherboardRepository { get; }
    public IPcComponentRepository<PcCase> PcCaseRepository { get; }
    public IPcComponentRepository<PowerSupply> PowerSupplyRepository { get; }
    public IPcComponentRepository<Ram> RamRepository { get; }
    public IPcComponentRepository<Ssd> SsdRepository { get; }
    public IPcComponentRepository<Videocard> VideocardRepository { get; }
    public IPcComponentRepository<WiFiAdapter> WiFiRepository { get; }
    public IPcComponentRepository<XmpProfile> XmpProfileRepository { get; }
}