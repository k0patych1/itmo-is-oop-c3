using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class RamBuilder
{
    private string? _name;
    private int? _amountOfAvailableMemorySize;
    private RamFormFactor? _formFactor;
    private DddrStandardVersion? _dddrStandardVersion;
    private int? _powerConsumption;
    private JedecProfile? _jedecProfile;
    private IReadOnlyCollection<XmpProfile>? _availableXmpProfiles;

    public RamBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public RamBuilder WithAmountOfAvailableMemorySize(int amountOfAvailableMemorySize)
    {
        if (amountOfAvailableMemorySize < 0)
            throw new NegativeArgumentException(nameof(amountOfAvailableMemorySize));

        _amountOfAvailableMemorySize = amountOfAvailableMemorySize;

        return this;
    }

    public RamBuilder WithFormFactor(RamFormFactor formFactor)
    {
        _formFactor = formFactor;

        return this;
    }

    public RamBuilder WithDddrStandardVersion(DddrStandardVersion dddrStandardVersion)
    {
        _dddrStandardVersion = dddrStandardVersion;

        return this;
    }

    public RamBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public RamBuilder WithJedecProfile(JedecProfile jedecProfile)
    {
        _jedecProfile = jedecProfile;

        return this;
    }

    public RamBuilder WithAvailableXmpProfiles(IReadOnlyCollection<XmpProfile> availableXmpProfiles)
    {
        _availableXmpProfiles = availableXmpProfiles;

        return this;
    }

    public Ram Build()
    {
        return new Ram(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _amountOfAvailableMemorySize ?? throw new ArgumentNullException(nameof(_amountOfAvailableMemorySize)),
            _formFactor ?? throw new ArgumentNullException(nameof(_formFactor)),
            _dddrStandardVersion ?? throw new ArgumentNullException(nameof(_dddrStandardVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)),
            _jedecProfile ?? throw new ArgumentNullException(nameof(_jedecProfile)),
            _availableXmpProfiles ?? throw new ArgumentNullException(nameof(_availableXmpProfiles)));
    }

    public RamBuilder Direct(Ram pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _powerConsumption = pcComponent.PowerConsumption;
        _formFactor = pcComponent.FormFactor;
        _amountOfAvailableMemorySize = pcComponent.AmountOfAvailableMemorySize;
        _dddrStandardVersion = pcComponent.DdrStandardVersion;
        _availableXmpProfiles = pcComponent.AvailableXmpProfiles;
        _jedecProfile = pcComponent.JedecProfile;

        return this;
    }
}