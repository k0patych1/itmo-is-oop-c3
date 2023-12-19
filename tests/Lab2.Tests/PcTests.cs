using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Directors;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class PcTests
{
    [Fact]
    public void ValidPcTesting()
    {
        Pc pcFromInternet = CreateValidPcFromSpecificationFromInternet();

        ValidationReport validationReport = new PcValidator().Validate(pcFromInternet);

        Assert.Equal(ValidationResult.Success, validationReport.ValidationResult);
        Assert.NotNull(pcFromInternet);
        Assert.Null(validationReport.Description);
    }

    [Fact]
    public void PcWithWeakCpuCoolingSystemTesting()
    {
        CpuCoolingSystem weakCpuCoolingSystem = CreateRepositoryFromInternet()
            .CpuCoolingSystemRepository
            .GetPcComponent("Gamma archer mini");

        var validator = new PcValidator();

        Pc pcFromInternet = CreateValidPcFromSpecificationFromInternet();
        Pc pcWithWeakCpuCoolingSystem = new PcBuilder(validator)
            .Direct(pcFromInternet)
            .WithCpuCoolingSystem(weakCpuCoolingSystem)
            .Build();

        ValidationReport validationReport = validator.Validate(pcWithWeakCpuCoolingSystem);

        Assert.Equal(
            ValidationResult.DisclaimerOfWarranty,
            validationReport.ValidationResult);
        Assert.NotNull(pcWithWeakCpuCoolingSystem);
        Assert.NotNull(validationReport.Description);
    }

    [Fact]
    public void PcWithWeakPowerSupplyTesting()
    {
        PowerSupply weakPowerSupply = CreateRepositoryFromInternet()
            .PowerSupplyRepository
            .GetPcComponent("Aerocool VX PLUS");

        var validator = new PcValidator();

        Pc pcFromInternet = CreateValidPcFromSpecificationFromInternet();
        Pc pcWithWeakPowerSupply = new PcBuilder(validator)
            .Direct(pcFromInternet)
            .WithPowerSupply(weakPowerSupply)
            .Build();

        ValidationReport validationReport = validator.Validate(pcWithWeakPowerSupply);

        Assert.Equal(ValidationResult.DisclaimerOfWarranty, validationReport.ValidationResult);
        Assert.NotNull(pcWithWeakPowerSupply);
        Assert.NotNull(validationReport.Description);
    }

    [Fact]
    public void PcWithIncompatibleSocket()
    {
        Motherboard motherboardWithIncompatibleSocket = CreateRepositoryFromInternet()
            .MotherboardRepository
            .GetPcComponent("palit vash dom spalit");

        var validator = new PcValidator();

        Pc pcFromInternet = CreateValidPcFromSpecificationFromInternet();

        PcBuilder pcWithWeakCpuCoolingSystem = new PcBuilder(validator)
            .Direct(pcFromInternet)
            .WithMotherboard(motherboardWithIncompatibleSocket);

        try
        {
            ValidationReport validationReport = validator.Validate(pcWithWeakCpuCoolingSystem.Build());
            Assert.Equal(ValidationResult.Failure, validationReport.ValidationResult);
            Assert.NotNull(pcWithWeakCpuCoolingSystem);
            Assert.NotNull(validationReport.Description);
        }
        catch (BuildingPcException)
        {
        }
    }

    private static AllPcComponentRepository CreateRepositoryFromInternet()
    {
        var repository = new AllPcComponentRepository();

        Cpu cpu = new CpuBuilder()
            .WithName("Intel Core i5 - 12400F OEM")
            .WithSocket(new Socket("LGA 1700"))
            .WithCoreFrequency(4400)
            .WithTdp(117)
            .WithPowerConsumption(117)
            .WithNumOfCores(6)
            .WithSupportedMemoryFrequency(4800)
            .WithIsBuiltInVideoCore(false)
            .Build();

        repository.CpuRepository.Create("Intel Core i5 - 12400F OEM", cpu);

        Bios bios = new BiosBuilder()
            .WithName("0419")
            .WithSupportedProcessors(new List<string> { "Intel Core i5 - 12400F OEM" })
            .WithType(new BiosType("0419"))
            .WithVersion(new BiosVersion("0419"))
            .Build();

        repository.BiosRepository.Create("0419", bios);

        var xmpProfile = new XmpProfile("xmp 3.0", new Timings("15-17-36"));
        var chipset = new Chipset(
            "Intel B660",
            2133,
            new List<XmpProfile> { xmpProfile },
            false);

        Motherboard motherboard = new MotherboardBuilder()
            .WithName("ASUS PRIME B660M-K D4")
            .WithSocket(new Socket("LGA 1700"))
            .WithBios(bios)
            .WithChipset(chipset)
            .WithFormFactor(new MotherboardFormFactor("mATX"))
            .WithSupportedDddr(new DddrStandardVersion("DDR4"))
            .WithNumOfPcieLines(19)
            .WithNumOfRamSlots(2)
            .WithNumOfSataPorts(4)
            .Build();

        repository.MotherboardRepository.Create("ASUS PRIME B660M-K D4", motherboard);

        var supportedSockets = new List<Socket>()
        {
            new Socket("AM4"),
            new Socket("LGA 1150"),
            new Socket("LGA 1151"),
            new Socket("LGA 1151-v2"),
            new Socket("LGA 1155"),
            new Socket("LGA 1156"),
            new Socket("LGA 1200"),
            new Socket("LGA 1700"),
        };

        CpuCoolingSystem cpuCoolingSystem = new CpuCoolingSystemBuilder()
            .WithName("ID-COOLING SE-214-XT")
            .WithTdp(180)
            .WithDimensions(new Dimensions(50, 72, 124))
            .WithSupportedSockets(supportedSockets)
            .Build();

        repository.CpuCoolingSystemRepository.Create("ID-COOLING SE-214-XT", cpuCoolingSystem);

        Ram ram = new RamBuilder()
            .WithName("Patriot viper 4")
            .WithFormFactor(new RamFormFactor("DIMM"))
            .WithPowerConsumption(4)
            .WithAvailableXmpProfiles(new List<XmpProfile> { xmpProfile })
            .WithDddrStandardVersion(new DddrStandardVersion("DDDR4"))
            .WithAmountOfAvailableMemorySize(16)
            .WithJedecProfile(new JedecProfile(new Timings("15-16-33"), 3, 3400))
            .Build();

        repository.RamRepository.Create("Patriot viper 4", ram);

        Videocard videocard = new VideocardBuilder()
            .WithName("NVIDIA GeForce RTX 4060 Ti")
            .WithPowerConsumption(181)
            .WithDimensions(new Dimensions(41, 115, 272))
            .WithChipFrequency(2550)
            .WithPcieVersion(new PcieVersion("4.0"))
            .WithVideoMemoryAmount(8)
            .Build();

        repository.VideocardRepository.Create("NVIDIA GeForce RTX 4060 Ti", videocard);

        Ssd ssd = new SsdBuilder()
            .WithName("ADATA XPG SX8200 Pro")
            .WithPowerConsumption(6)
            .WithCapacity(2000)
            .WithConnectionOption(new ConnectionOption("PCIE"))
            .WithMaximumOperatingSpeed(3350)
            .Build();

        repository.SsdRepository.Create("ADATA XPG SX8200 Pro", ssd);

        PcCase pcCase = new PcCaseBuilder()
            .WithName("Zalman N5 OF Black")
            .WithDimensions(new Dimensions(450, 437, 200))
            .WithSupportedMotherboardFormFactors(new List<MotherboardFormFactor>
                {
                    new MotherboardFormFactor("ATX"),
                    new MotherboardFormFactor("mATX"),
                    new MotherboardFormFactor("Mini-ITX"),
                })
            .WithMaximumDimensionsOfTheVideocard(new Dimensions(73, 158, 365))
            .Build();

        repository.PcCaseRepository.Create("Zalman N5 OF Black", pcCase);

        PowerSupply powerSupply = new PowerSupplyBuilder()
            .WithName("Chieftec Element")
            .WithPeakLoad(700)
            .Build();

        repository.PowerSupplyRepository.Create("Chieftec Element", powerSupply);

        CpuCoolingSystem imaginaryWeakCpuCoolingSystem = new CpuCoolingSystemBuilder()
            .Direct(cpuCoolingSystem)
            .WithName("gamma archer mini")
            .WithTdp(10)
            .Build();

        repository.CpuCoolingSystemRepository.Create("Gamma archer mini", imaginaryWeakCpuCoolingSystem);

        PowerSupply weakPowerSupply = new PowerSupplyBuilder()
            .WithName("Aerocool VX PLUS")
            .WithPeakLoad(400)
            .Build();

        repository.PowerSupplyRepository.Create("Aerocool VX PLUS", weakPowerSupply);

        Motherboard motherboardWithNewSocket = new MotherboardBuilder()
            .Direct(motherboard)
            .WithName("palit vash dom spalit")
            .WithSocket(new Socket("AM5"))
            .Build();

        repository.MotherboardRepository.Create("palit vash dom spalit", motherboardWithNewSocket);

        return repository;
    }

    private static Pc CreateValidPcFromSpecificationFromInternet()
    {
        var pcBuilder = new PcBuilder(new PcValidator());
        var pcDirector = new PcDirector(CreateRepositoryFromInternet(), pcBuilder);

        var ramNames = new Collection<string>()
        {
            "Patriot viper 4",
            "Patriot viper 4",
        };

        var hddNames = new Collection<string>();

        var ssdNames = new List<string> { "ADATA XPG SX8200 Pro" };

        var specification = new Specification(
            "0419",
            "Intel Core i5 - 12400F OEM",
            "ID-COOLING SE-214-XT",
            "ASUS PRIME B660M-K D4",
            "Zalman N5 OF Black",
            "Chieftec Element",
            hddNames,
            ramNames,
            ssdNames,
            "NVIDIA GeForce RTX 4060 Ti",
            null,
            null);

        pcDirector.Direct(specification);

        return pcBuilder.Build();
    }
}