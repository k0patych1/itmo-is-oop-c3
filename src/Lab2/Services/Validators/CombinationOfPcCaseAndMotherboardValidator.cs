using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfPcCaseAndMotherboardValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        return pc.PcCase.SupportedMotherboardFormFactors.Contains(pc.Motherboard.FormFactor)
            ? new ValidationReport(ValidationResult.Success, null)
            : new ValidationReport(ValidationResult.Failure, "ERROR :motherboard and CPU are incompatible.");
    }
}