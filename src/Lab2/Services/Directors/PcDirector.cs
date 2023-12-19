using System.Diagnostics.CodeAnalysis;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Directors;

public class PcDirector
{
    private readonly AllPcComponentRepository _pcComponentRepository;
    private readonly PcBuilder _builder;

    public PcDirector(AllPcComponentRepository pcComponentRepository, PcBuilder builder)
    {
        _pcComponentRepository = pcComponentRepository;
        _builder = builder;
    }

    public void Direct([NotNull] Specification specification)
    {
        _builder.WithCpu(_pcComponentRepository.CpuRepository.GetPcComponent(specification.CpuName))
            .WithCpuCoolingSystem(_pcComponentRepository.CpuCoolingSystemRepository
                .GetPcComponent(specification.CpuCoolingSystemName))
            .WithBios(_pcComponentRepository.BiosRepository.GetPcComponent(specification.BiosName))
            .WithMotherboard(_pcComponentRepository.MotherboardRepository
                .GetPcComponent(specification.MotherboardName))
            .WithPcCase(_pcComponentRepository.PcCaseRepository
                .GetPcComponent(specification.PcCaseName))
            .WithPowerSupply(_pcComponentRepository.PowerSupplyRepository
                .GetPcComponent(specification.PowerSupplyName));
        if (specification.VideocardName is not null)
        {
            _builder.WithVideocard(_pcComponentRepository.VideocardRepository
                .GetPcComponent(specification.VideocardName));
        }

        if (specification.WiFiAdapterName is not null)
        {
            _builder.WithWiFiAdapter(_pcComponentRepository.WiFiRepository
                .GetPcComponent(specification.WiFiAdapterName));
        }

        if (specification.XmpProfileName is not null)
        {
            _builder.WithXmpProfile(_pcComponentRepository.XmpProfileRepository
                .GetPcComponent(specification.XmpProfileName));
        }

        foreach (string ssdName in specification.SsdNames)
        {
            _builder.WithSsd(_pcComponentRepository.SsdRepository.GetPcComponent(ssdName));
        }

        foreach (string hddName in specification.HddNames)
        {
            _builder.WithHdd(_pcComponentRepository.HddRepository.GetPcComponent(hddName));
        }

        foreach (string ramName in specification.RamNames)
        {
            _builder.WithRam(_pcComponentRepository.RamRepository.GetPcComponent(ramName));
        }
    }
}