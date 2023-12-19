using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class CpuBuilder
{
    private string? _name;
    private int? _coreFrequency;
    private int? _numOfCores;
    private Socket? _socket;
    private bool? _isBuiltInVideoCore;
    private int? _supportedMemoryFrequency;
    private int? _tdp;
    private int? _powerConsumption;

    public CpuBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public CpuBuilder WithCoreFrequency(int coreFrequency)
    {
        if (coreFrequency < 0) throw new NegativeArgumentException(nameof(coreFrequency));

        _coreFrequency = coreFrequency;

        return this;
    }

    public CpuBuilder WithNumOfCores(int numOfCores)
    {
        if (numOfCores < 0) throw new NegativeArgumentException(nameof(numOfCores));

        _numOfCores = numOfCores;

        return this;
    }

    public CpuBuilder WithSocket(Socket socket)
    {
        _socket = socket;

        return this;
    }

    public CpuBuilder WithIsBuiltInVideoCore(bool isBuiltInVideoCore)
    {
        _isBuiltInVideoCore = isBuiltInVideoCore;

        return this;
    }

    public CpuBuilder WithSupportedMemoryFrequency(int supportedMemoryFrequency)
    {
        if (supportedMemoryFrequency < 0)
            throw new NegativeArgumentException(nameof(supportedMemoryFrequency));

        _supportedMemoryFrequency = supportedMemoryFrequency;

        return this;
    }

    public CpuBuilder WithTdp(int tdp)
    {
        if (tdp < 0) throw new NegativeArgumentException(nameof(tdp));

        _tdp = tdp;

        return this;
    }

    public CpuBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _coreFrequency ?? throw new ArgumentNullException(nameof(_coreFrequency)),
            _numOfCores ?? throw new ArgumentNullException(nameof(_numOfCores)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _isBuiltInVideoCore ?? throw new ArgumentNullException(nameof(_isBuiltInVideoCore)),
            _supportedMemoryFrequency ?? throw new ArgumentNullException(nameof(_supportedMemoryFrequency)),
            _tdp ?? throw new ArgumentNullException(nameof(_tdp)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }

    public CpuBuilder Direct(Cpu pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _coreFrequency = pcComponent.CoreFrequency;
        _tdp = pcComponent.Tdp;
        _powerConsumption = pcComponent.PowerConsumption;
        _numOfCores = pcComponent.NumOfCores;
        _socket = pcComponent.Socket;
        _supportedMemoryFrequency = pcComponent.SupportedMemoryFrequency;
        _isBuiltInVideoCore = pcComponent.IsBuiltInVideoCore;

        return this;
    }
}