using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Cpu;

public class Cpu : PcComponentBase
{
    public Cpu(
        string name,
        int coreFrequency,
        int numOfCores,
        Socket socket,
        bool isBuiltInVideoCore,
        int supportedMemoryFrequency,
        int tdp,
        int powerConsumption)
        : base(name)
    {
        if (numOfCores < 0) throw new NegativeArgumentException(nameof(numOfCores));
        if (coreFrequency < 0) throw new NegativeArgumentException(nameof(coreFrequency));
        if (supportedMemoryFrequency < 0) throw new NegativeArgumentException(nameof(supportedMemoryFrequency));
        if (tdp < 0) throw new NegativeArgumentException(nameof(tdp));
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        CoreFrequency = coreFrequency;
        NumOfCores = numOfCores;
        Socket = socket;
        IsBuiltInVideoCore = isBuiltInVideoCore;
        SupportedMemoryFrequency = supportedMemoryFrequency;
        Tdp = tdp;
        PowerConsumption = powerConsumption;
    }

    public int CoreFrequency { get; }
    public int NumOfCores { get; }
    public Socket Socket { get; }
    public bool IsBuiltInVideoCore { get; }
    public int SupportedMemoryFrequency { get; }
    public int Tdp { get; }
    public int PowerConsumption { get; }
}