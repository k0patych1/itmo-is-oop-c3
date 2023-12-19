using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.WiFiAdapter;

public class WiFiAdapter : PcComponentBase
{
    public WiFiAdapter(
        string name,
        WiFiStandardVersion wiFiStandardVersion,
        bool isBuiltInBluetoothModule,
        PcieVersion pcieVersion,
        int powerConsumption)
        : base(name)
    {
        if (powerConsumption < 0) throw new NegativeArgumentException(nameof(powerConsumption));

        WiFiStandardVersion = wiFiStandardVersion;
        IsBuiltInBluetoothModule = isBuiltInBluetoothModule;
        PcieVersion = pcieVersion;
        PowerConsumption = powerConsumption;
    }

    public WiFiStandardVersion WiFiStandardVersion { get; }
    public bool IsBuiltInBluetoothModule { get; }
    public PcieVersion PcieVersion { get; }
    public int PowerConsumption { get; }
}