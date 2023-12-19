using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfCpuAndMotherboardValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        return pc.Motherboard.Socket != pc.Cpu.Socket ?
            new ValidationReport(ValidationResult.Failure, "ERROR : motherboard and CPU are incompatible.")
            : new ValidationReport(ValidationResult.Success, null);
    }
}