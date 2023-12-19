using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class BiosBuilder
{
    private string? _name;
    private BiosType? _type;
    private BiosVersion? _version;
    private IReadOnlyCollection<string>? _supportedProcessors;

    public BiosBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public BiosBuilder WithType(BiosType type)
    {
        _type = type;

        return this;
    }

    public BiosBuilder WithVersion(BiosVersion version)
    {
        _version = version;

        return this;
    }

    public BiosBuilder WithSupportedProcessors(IReadOnlyCollection<string> supportedProcessors)
    {
        _supportedProcessors = supportedProcessors;

        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _type ?? throw new ArgumentNullException(nameof(_type)),
            _version ?? throw new ArgumentNullException(nameof(_version)),
            _supportedProcessors ?? throw new ArgumentNullException(nameof(_supportedProcessors)));
    }

    public BiosBuilder Direct(Bios pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _type = pcComponent.Type;
        _supportedProcessors = pcComponent.SupportedProcessors;
        _version = pcComponent.Version;

        return this;
    }
}