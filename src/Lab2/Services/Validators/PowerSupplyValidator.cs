using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class PowerSupplyValidator : IPcComponentValidator
{
    private static int RecommendedPowerReserve => 100;

    public ValidationReport Validate([NotNull] Pc pc)
    {
        int requiredPower = 0;

        if (pc.Videocard is not null)
        {
            requiredPower += pc.Videocard.PowerConsumption;
        }

        if (pc.WiFiAdapter is not null)
        {
            requiredPower += pc.WiFiAdapter.PowerConsumption;
        }

        requiredPower += pc.Cpu.PowerConsumption;

        requiredPower += pc.RamSticks.Sum(ram => ram.PowerConsumption);

        requiredPower += pc.Ssds.Sum(ssd => ssd.PowerConsumption);

        requiredPower += pc.Hdds.Sum(hdd => hdd.PowerConsumption);

        if (pc.PowerSupply.PeakLoad < requiredPower)
        {
            return new ValidationReport(
                ValidationResult.Failure,
                "ERROR : System consumption exceeds power supply peak load.");
        }

        if (pc.PowerSupply.PeakLoad - requiredPower < RecommendedPowerReserve)
        {
            return new ValidationReport(
                ValidationResult.DisclaimerOfWarranty,
                "!DisclaimerOfWarranty! : The power supply may not be able to cope with the system during peak loads.");
        }

        return new ValidationReport(ValidationResult.Success, null);
    }
}