using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class HddBuilder
{
    private string? _name;
    private int? _capacity;
    private int? _spindleSpeed;
    private int? _powerConsumption;

    public HddBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public HddBuilder WithCapacity(int capacity)
    {
        if (capacity < 0) throw new NegativeArgumentException(nameof(capacity));

        _capacity = capacity;

        return this;
    }

    public HddBuilder WithSpindleSpeed(int spindleSpeed)
    {
        if (spindleSpeed < 0) throw new NegativeArgumentException(nameof(spindleSpeed));

        _spindleSpeed = spindleSpeed;

        return this;
    }

    public HddBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public Hdd Build()
    {
        return new Hdd(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _capacity ?? throw new ArgumentNullException(nameof(_capacity)),
            _spindleSpeed ?? throw new ArgumentNullException(nameof(_spindleSpeed)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }

    public HddBuilder Direct(Hdd pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _capacity = pcComponent.Capacity;
        _spindleSpeed = pcComponent.SpindleSpeed;
        _powerConsumption = pcComponent.PowerConsumption;

        return this;
    }
}