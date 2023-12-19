using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PcCase;

public class PcCase : PcComponentBase
{
    public PcCase(
        string name,
        Dimensions maximumDimensionsOfTheVideocard,
        IReadOnlyCollection<MotherboardFormFactor> supportedMotherboardFormFactors,
        Dimensions dimensions)
        : base(name)
    {
        MaximumDimensionsOfTheVideocard = maximumDimensionsOfTheVideocard;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public Dimensions MaximumDimensionsOfTheVideocard { get; }
    public IReadOnlyCollection<MotherboardFormFactor> SupportedMotherboardFormFactors { get; }
    public Dimensions Dimensions { get; }
}