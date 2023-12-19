using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.BIOS;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.CpuCoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Motherboard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.PowerSupply;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Videocard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.XMPProfile;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Validators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcBuilders;

public class PcBuilder
{
    private readonly IPcComponentValidator _pcComponentValidator;
    private Motherboard? _motherboard;
    private Cpu? _cpu;
    private CpuCoolingSystem? _cpuCoolingSystem;
    private Collection<Hdd> _hdds;
    private Collection<Ssd> _ssds;
    private PcCase? _pcCase;
    private PowerSupply? _powerSupply;
    private Collection<Ram> _ramSticks;
    private Videocard? _videocard;
    private WiFiAdapter? _wiFiAdapter;
    private XmpProfile? _xmpProfile;
    private Bios? _bios;

    public PcBuilder(IPcComponentValidator validator)
    {
        _pcComponentValidator = validator;
        _hdds = new Collection<Hdd>();
        _ssds = new BindingList<Ssd>();
        _ramSticks = new Collection<Ram>();
    }

    public ValidationReport? ValidationReport { get; private set; }

    public PcBuilder WithMotherboard(Motherboard motherboard)
    {
        _motherboard = motherboard;

        return this;
    }

    public PcBuilder WithCpu(Cpu cpu)
    {
        _cpu = cpu;

        return this;
    }

    public PcBuilder WithCpuCoolingSystem(CpuCoolingSystem cpuCoolingSystem)
    {
        _cpuCoolingSystem = cpuCoolingSystem;

        return this;
    }

    public PcBuilder WithHdd(Hdd hdd)
    {
        _hdds.Add(hdd);

        return this;
    }

    public PcBuilder WithSsd(Ssd ssd)
    {
        _ssds.Add(ssd);

        return this;
    }

    public PcBuilder WithPcCase(PcCase pcCase)
    {
        _pcCase = pcCase;

        return this;
    }

    public PcBuilder WithPowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;

        return this;
    }

    public PcBuilder WithRam(Ram ram)
    {
        _ramSticks.Add(ram);

        return this;
    }

    public PcBuilder WithVideocard(Videocard? videocard)
    {
        _videocard = videocard;

        return this;
    }

    public PcBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;

        return this;
    }

    public PcBuilder WithXmpProfile(XmpProfile? xmpProfile)
    {
        _xmpProfile = xmpProfile;

        return this;
    }

    public PcBuilder WithBios(Bios? bios)
    {
        _bios = bios;

        return this;
    }

    public Pc Build()
    {
        if (_motherboard is null || _cpu is null || _cpuCoolingSystem is null || _bios is null
            || _pcCase is null || _powerSupply is null || _ramSticks.Count is 0)
        {
            throw new BuildingPcException("Missing required PC component");
        }

        var pc = new Pc(
            _motherboard,
            _cpu,
            _bios,
            _cpuCoolingSystem,
            _ramSticks,
            _xmpProfile,
            _videocard,
            _ssds,
            _hdds,
            _pcCase,
            _powerSupply,
            _wiFiAdapter);

        ValidationReport = _pcComponentValidator.Validate(pc);

        if (ValidationReport.ValidationResult is not ValidationResult.Failure) return pc;
        if (ValidationReport.Description != null) throw new BuildingPcException(ValidationReport.Description);
        throw new BuildingPcException("Failed to build computer due to unknown error");
    }

    public PcBuilder Direct(Pc otherPc)
    {
        if (otherPc == null)
        {
            throw new ArgumentNullException(nameof(otherPc));
        }

        _motherboard = otherPc.Motherboard;
        _cpu = otherPc.Cpu;
        _cpuCoolingSystem = otherPc.CpuCoolingSystem;
        _hdds = new Collection<Hdd>(otherPc.Hdds);
        _ssds = new Collection<Ssd>(otherPc.Ssds);
        _pcCase = otherPc.PcCase;
        _powerSupply = otherPc.PowerSupply;
        _ramSticks = new Collection<Ram>(otherPc.RamSticks);
        _videocard = otherPc.Videocard;
        _wiFiAdapter = otherPc.WiFiAdapter;
        _xmpProfile = otherPc.XmpProfile;
        _bios = otherPc.Bios;

        return this;
    }
}