using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class PowerSupplyBuilder
{
    private string? _name;
    private int? _peakLoad;

    public PowerSupplyBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public PowerSupplyBuilder WithPeakLoad(int peakLoad)
    {
        if (peakLoad < 0) throw new NegativeArgumentException(nameof(peakLoad));

        _peakLoad = peakLoad;

        return this;
    }

    public PowerSupply Build()
    {
        return new PowerSupply(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _peakLoad ?? throw new ArgumentNullException(nameof(_peakLoad)));
    }

    public PowerSupplyBuilder Direct(PowerSupply pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _peakLoad = pcComponent.PeakLoad;

        return this;
    }
}