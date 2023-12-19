using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfCpuAndCpuCoolingSystemValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        if (!pc.CpuCoolingSystem.SupportedSockets.Contains<Socket>(pc.Cpu.Socket))
        {
            return new ValidationReport(
                ValidationResult.Failure,
                "ERROR : cooling system isn't compatible with CPU.");
        }

        if (pc.CpuCoolingSystem.Tdp < pc.Cpu.Tdp)
        {
            return new ValidationReport(
                ValidationResult.DisclaimerOfWarranty,
                "!DisclaimerOfWarranty! : TDP of cpu is greater than maximal tdp of cpu cooling system.");
        }

        return new ValidationReport(ValidationResult.Success, null);
    }
}