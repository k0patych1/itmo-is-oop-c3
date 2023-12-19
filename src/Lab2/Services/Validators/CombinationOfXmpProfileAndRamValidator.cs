using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

public class CombinationOfXmpProfileAndRamValidator : IPcComponentValidator
{
    public ValidationReport Validate([NotNull] Pc pc)
    {
        if (pc.Motherboard.NumOfRamSlots < pc.RamSticks.Count)
        {
            return new ValidationReport(
                ValidationResult.Failure,
                "ERROR : number of ram sticks is greater than the slots of motherboard");
        }

        if (pc.RamSticks.Any(ram => ram.DdrStandardVersion != pc.Motherboard.SupportedDddr))
        {
            return new ValidationReport(ValidationResult.Success, null);
        }

        if (pc.RamSticks.All(ram =>
                ram.JedecProfile.Frequency > pc.Motherboard.Chipset.AvailableMemoryFrequencies
                || (pc.XmpProfile != null
                    && pc.XmpProfile.Frequency >= pc.Motherboard.Chipset.AvailableMemoryFrequencies
                    && pc.Cpu.SupportedMemoryFrequency >= pc.XmpProfile.Frequency
                    && pc.Motherboard.Chipset.SupportedXmpProfiles.Contains<XmpProfile>(pc.XmpProfile)
                    && ram.AvailableXmpProfiles.Contains<XmpProfile>(pc.XmpProfile))))
        {
            return new ValidationReport(ValidationResult.Success, null);
        }

        return new ValidationReport(
            ValidationResult.Failure, "ERROR : motherboard and RAM are incompatible.");
    }
}