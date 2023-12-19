using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class CpuCoolingSystemBuilder
{
    private string? _name;
    private Dimensions? _dimensions;
    private int? _tdp;
    private IReadOnlyCollection<Socket>? _supportedSockets;

    public CpuCoolingSystemBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public CpuCoolingSystemBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;

        return this;
    }

    public CpuCoolingSystemBuilder WithTdp(int tdp)
    {
        if (tdp < 0) throw new NegativeArgumentException(nameof(tdp));

        _tdp = tdp;

        return this;
    }

    public CpuCoolingSystemBuilder WithSupportedSockets(IReadOnlyCollection<Socket> supportedSockets)
    {
        _supportedSockets = supportedSockets;

        return this;
    }

    public CpuCoolingSystem Build()
    {
        return new CpuCoolingSystem(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _supportedSockets ?? throw new ArgumentNullException(nameof(_supportedSockets)));
    }

    public CpuCoolingSystemBuilder Direct(CpuCoolingSystem pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _dimensions = pcComponent.Dimensions;
        _tdp = pcComponent.Tdp;
        _supportedSockets = pcComponent.SupportedSockets;

        return this;
    }
}