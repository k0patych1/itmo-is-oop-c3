using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfVideocardAndPowerSupplyValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        if (pc.Videocard is null && !pc.Cpu.IsBuiltInVideoCore)
        {
            return new ValidationReport(
                ValidationResult.Failure,
                "ERROR : the computer has neither a video card nor a video core.");
        }

        if (pc.Videocard?.Dimensions.Depth > pc.PcCase.Dimensions.Depth
            || pc.Videocard?.Dimensions.Height > pc.PcCase.Dimensions.Height
            || pc.Videocard?.Dimensions.Width > pc.PcCase.Dimensions.Width)
        {
            return new ValidationReport(ValidationResult.Success, null);
        }

        return new ValidationReport(ValidationResult.Failure, "ERROR : video card doesn't fit in pc case.");
    }
}