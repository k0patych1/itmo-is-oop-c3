using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.CpuCoolingSystem;

public class CpuCoolingSystem : PcComponentBase
{
    public CpuCoolingSystem(string name, Dimensions dimensions, int tdp, IReadOnlyCollection<Socket> supportedSockets)
        : base(name)
    {
        if (tdp < 0) throw new NegativeArgumentException(nameof(tdp));

        Dimensions = dimensions;
        Tdp = tdp;
        SupportedSockets = supportedSockets;
    }

    public Dimensions Dimensions { get; }
    public int Tdp { get; }
    public IReadOnlyCollection<Socket> SupportedSockets { get; }
}