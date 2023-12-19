using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.WiFiAdapter;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders.PcComponentsBuilders;

public class WiFiAdapterBuilder
{
    private string? _name;
    private WiFiStandardVersion? _wiFiStandardVersion;
    private bool? _isBuiltInBluetoothModule;
    private PcieVersion? _pcieVersion;
    private int? _powerConsumption;

    public WiFiAdapterBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public WiFiAdapterBuilder WithWiFiStandardVersion(WiFiStandardVersion wiFiStandardVersion)
    {
        _wiFiStandardVersion = wiFiStandardVersion;

        return this;
    }

    public WiFiAdapterBuilder WithIsBuiltInBluetoothModule(bool isBuiltInBluetoothModule)
    {
        _isBuiltInBluetoothModule = isBuiltInBluetoothModule;

        return this;
    }

    public WiFiAdapterBuilder WithPcieVersion(PcieVersion pcieVersion)
    {
        _pcieVersion = pcieVersion;

        return this;
    }

    public WiFiAdapterBuilder WithPowerConsumption(int powerConsumption)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        _powerConsumption = powerConsumption;

        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _wiFiStandardVersion ?? throw new ArgumentNullException(nameof(_wiFiStandardVersion)),
            _isBuiltInBluetoothModule ?? throw new ArgumentNullException(nameof(_isBuiltInBluetoothModule)),
            _pcieVersion ?? throw new ArgumentNullException(nameof(_pcieVersion)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }

    public WiFiAdapterBuilder Direct(WiFiAdapter pcComponent)
    {
        if (pcComponent == null)
        {
            throw new ArgumentNullException(nameof(pcComponent));
        }

        _name = pcComponent.Name;
        _powerConsumption = pcComponent.PowerConsumption;
        _pcieVersion = pcComponent.PcieVersion;
        _wiFiStandardVersion = pcComponent.WiFiStandardVersion;
        _isBuiltInBluetoothModule = pcComponent.IsBuiltInBluetoothModule;

        return this;
    }
}
