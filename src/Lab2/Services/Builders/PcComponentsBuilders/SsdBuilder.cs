using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class SsdBuilder
{
    private string? _name;
    private ConnectionOption? _connectionOption;
    private int? _capacity;
    private int? _maximumOperatingSpeed;
    private int? _powerConsumption;

    public SsdBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public SsdBuilder WithConnectionOption(ConnectionOption connectionOption)
    {
        _connectionOption = connectionOption;

        return this;
    }

    public SsdBuilder WithCapacity(int capacity)
    {
        if (capacity < 0) throw new NegativeArgumentException(nameof(capacity));

        _capacity = capacity;

        return this;
    }

    public SsdBuilder WithMaximumOperatingSpeed(int maximumOperatingSpeed)
    {
        if (maximumOperatingSpeed < 0) throw new NegativeArgumentException(nameof(maximumOperatingSpeed));

        _maximumOperatingSpeed = maximumOperatingSpeed;

        return this;
    }

    public SsdBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public Ssd Build()
    {
        return new Ssd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _connectionOption ?? throw new ArgumentNullException(nameof(_connectionOption)),
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _maximumOperatingSpeed ?? throw new ArgumentNullException(nameof(_maximumOperatingSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }

    public SsdBuilder Direct(Ssd pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _powerConsumption = pcComponent.PowerConsumption;
        _capacity = pcComponent.Capacity;
        _maximumOperatingSpeed = pcComponent.MaximumOperatingSpeed;
        _connectionOption = pcComponent.ConnectionOption;

        return this;
    }
}