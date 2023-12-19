using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Motherboard;

public class Motherboard : PcComponentBase
{
    public Motherboard(
        string name,
        Socket socket,
        int numOfPcieLines,
        int numOfSataPorts,
        Chipset chipset,
        DddrStandardVersion supportedDddr,
        int numOfRamSlots,
        MotherboardFormFactor formFactor,
        Bios bios)
        : base(name)
    {
        if (numOfPcieLines < 0) throw new NegativeArgumentException(nameof(numOfPcieLines));
        if (numOfSataPorts < 0) throw new NegativeArgumentException(nameof(numOfSataPorts));
        if (numOfRamSlots < 0) throw new NegativeArgumentException(nameof(numOfRamSlots));

        Socket = socket;
        NumOfPcieLines = numOfPcieLines;
        NumOfSataPorts = numOfSataPorts;
        Chipset = chipset;
        SupportedDddr = supportedDddr;
        NumOfRamSlots = numOfRamSlots;
        FormFactor = formFactor;
        Bios = bios;
    }

    public Socket Socket { get; }
    public int NumOfPcieLines { get; }
    public int NumOfSataPorts { get; }
    public Chipset Chipset { get; }
    public DddrStandardVersion SupportedDddr { get; }
    public int NumOfRamSlots { get; }
    public MotherboardFormFactor FormFactor { get; }
    public Bios Bios { get; }
}