using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfSsdAndHddValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        if (pc.Ssds.Count is 0 && pc.Hdds.Count is 0)
        {
            return new ValidationReport(ValidationResult.Failure, "ERROR : the computer has neither a ssd nor a hdd.");
        }

        int requiredSataPorts = pc.Ssds.Count(ssd => ssd.ConnectionOption.Name == "SATA") + pc.Hdds.Count;
        int requiredPcieLines = pc.Ssds.Count(ssd => ssd.ConnectionOption.Name != "SATA");

        if (requiredPcieLines > pc.Motherboard.NumOfPcieLines
            || requiredSataPorts > pc.Motherboard.NumOfSataPorts)
        {
            return new ValidationReport(ValidationResult.Failure, "ERROR : impossible to connect all drives.");
        }

        return new ValidationReport(ValidationResult.Success, null);
    }
}