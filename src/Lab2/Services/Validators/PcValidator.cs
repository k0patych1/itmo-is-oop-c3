using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PcValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        var combinationOfCpuAndBiosValidator = new CombinationOfCpuAndBiosValidator();
        var combinationOfCpuAndCpuCoolingSystemValidator = new CombinationOfCpuAndCpuCoolingSystemValidator();
        var combinationOfCpuAndMotherboardValidator = new CombinationOfCpuAndMotherboardValidator();
        var combinationOfXmpProfileAndRamValidator = new CombinationOfXmpProfileAndRamValidator();
        var combinationOfPcCaseAndMotherboardValidator = new CombinationOfPcCaseAndMotherboardValidator();
        var combinationOfVideocardAndPowerSupplyValidator = new CombinationOfVideocardAndPowerSupplyValidator();
        var powerSupplyValidator = new PowerSupplyValidator();
        var combinationOfSsdAndHddValidator = new CombinationOfSsdAndHddValidator();

        var validationReports = new Collection<ValidationReport>
        {
            combinationOfCpuAndBiosValidator.Validate(pc),
            combinationOfCpuAndCpuCoolingSystemValidator.Validate(pc),
            combinationOfCpuAndMotherboardValidator.Validate(pc),
            combinationOfXmpProfileAndRamValidator.Validate(pc),
            combinationOfPcCaseAndMotherboardValidator.Validate(pc),
            combinationOfVideocardAndPowerSupplyValidator.Validate(pc),
            powerSupplyValidator.Validate(pc),
            combinationOfSsdAndHddValidator.Validate(pc),
        };

        string finalReport = string.Join("\n", validationReports.
            Where(report => report.Description != null)
            .Select(report => report.Description));

        if (validationReports.Any(report => report.ValidationResult == ValidationResult.Failure))
            return new ValidationReport(ValidationResult.Failure, finalReport);

        return validationReports
            .Any(report => report.ValidationResult == ValidationResult.DisclaimerOfWarranty) ?
            new ValidationReport(ValidationResult.DisclaimerOfWarranty, finalReport)
            : new ValidationReport(ValidationResult.Success, null);
    }
}