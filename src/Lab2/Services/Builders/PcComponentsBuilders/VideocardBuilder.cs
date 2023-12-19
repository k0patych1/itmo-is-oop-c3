using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class VideocardBuilder
{
    private string? _name;
    private Dimensions? _dimensions;
    private int? _videoMemoryAmount;
    private PcieVersion? _pcieVersion;
    private int? _chipFrequency;
    private int? _powerConsumption;

    public VideocardBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public VideocardBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;

        return this;
    }

    public VideocardBuilder WithVideoMemoryAmount(int videoMemoryAmount)
    {
        if (videoMemoryAmount < 0) throw new NegativeArgumentException(nameof(videoMemoryAmount));

        _videoMemoryAmount = videoMemoryAmount;

        return this;
    }

    public VideocardBuilder WithPcieVersion(PcieVersion pcieVersion)
    {
        _pcieVersion = pcieVersion;

        return this;
    }

    public VideocardBuilder WithChipFrequency(int chipFrequency)
    {
        if (chipFrequency < 0) throw new NegativeArgumentException(nameof(chipFrequency));

        _chipFrequency = chipFrequency;

        return this;
    }

    public VideocardBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public Videocard Build()
    {
        return new Videocard(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _videoMemoryAmount ?? throw new ArgumentNullException(nameof(_videoMemoryAmount)),
            _pcieVersion ?? throw new ArgumentNullException(nameof(_pcieVersion)),
            _chipFrequency ?? throw new ArgumentNullException(nameof(_chipFrequency)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }

    public VideocardBuilder Direct(Videocard pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _powerConsumption = pcComponent.PowerConsumption;
        _chipFrequency = pcComponent.ChipFrequency;
        _dimensions = pcComponent.Dimensions;
        _videoMemoryAmount = pcComponent.VideoMemoryAmount;
        _pcieVersion = pcComponent.PcieVersion;

        return this;
    }
}