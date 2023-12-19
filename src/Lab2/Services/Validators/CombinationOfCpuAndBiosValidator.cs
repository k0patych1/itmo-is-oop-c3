using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfCpuAndBiosValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        return pc.Bios.SupportedProcessors.Contains<string>(pc.Cpu.Name)
            ? new ValidationReport(ValidationResult.Success, null)
            : new ValidationReport(ValidationResult.Failure, "ERROR : BIOS isn't compatible with CPU");
    }
}