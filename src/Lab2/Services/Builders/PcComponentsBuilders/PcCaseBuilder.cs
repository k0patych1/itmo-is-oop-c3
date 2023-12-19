using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class PcCaseBuilder
{
    private string? _name;
    private Dimensions? _maximumDimensionsOfTheVideocard;
    private IReadOnlyCollection<MotherboardFormFactor>? _supportedMotherboardFormFactors;
    private Dimensions? _dimensions;

    public PcCaseBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public PcCaseBuilder WithMaximumDimensionsOfTheVideocard(
        Dimensions maximumDimensionsOfTheVideocard)
    {
        _maximumDimensionsOfTheVideocard = maximumDimensionsOfTheVideocard;

        return this;
    }

    public PcCaseBuilder WithSupportedMotherboardFormFactors(
        IReadOnlyCollection<MotherboardFormFactor>? supportedMotherboardFormFactors)
    {
        _supportedMotherboardFormFactors = supportedMotherboardFormFactors;

        return this;
    }

    public PcCaseBuilder WithDimensions(Dimensions dimensions)
    {
        _dimensions = dimensions;

        return this;
    }

    public PcCase Build()
    {
        return new PcCase(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _maximumDimensionsOfTheVideocard ?? throw new ArgumentNullException(nameof(_maximumDimensionsOfTheVideocard)),
            _supportedMotherboardFormFactors ?? throw new ArgumentNullException(nameof(_supportedMotherboardFormFactors)),
            _dimensions ?? throw new ArgumentNullException(nameof(_dimensions)));
    }

    public PcCaseBuilder Direct(PcCase pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _dimensions = pcComponent.Dimensions;
        _supportedMotherboardFormFactors = pcComponent.SupportedMotherboardFormFactors;
        _maximumDimensionsOfTheVideocard = pcComponent.MaximumDimensionsOfTheVideocard;

        return this;
    }
}