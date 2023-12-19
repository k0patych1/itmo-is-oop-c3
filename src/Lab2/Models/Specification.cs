using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public record Specification(
    string BiosName,
    string CpuName,
    string CpuCoolingSystemName,
    string MotherboardName,
    string PcCaseName,
    string PowerSupplyName,
    IReadOnlyCollection<string> HddNames,
    IReadOnlyCollection<string> RamNames,
    IReadOnlyCollection<string> SsdNames,
    string? VideocardName,
    string? WiFiAdapterName,
    string? XmpProfileName);