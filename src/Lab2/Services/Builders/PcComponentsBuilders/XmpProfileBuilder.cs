using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class XmpProfileBuilder
{
    private string? _name;
    private Timings? _timings;

    public XmpProfileBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public XmpProfileBuilder WithTimings(Timings timings)
    {
        _timings = timings;

        return this;
    }

    public XmpProfile Build()
    {
        return new XmpProfile(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _timings ?? throw new ArgumentNullException(nameof(_timings)));
    }

    public XmpProfileBuilder Direct(XmpProfile pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _timings = pcComponent.Timings;

        return this;
    }
}