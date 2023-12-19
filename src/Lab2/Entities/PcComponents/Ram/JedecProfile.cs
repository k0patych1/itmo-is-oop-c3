using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models.PcComponentsParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents.Ram;

public class JedecProfile
{
    public JedecProfile(Timings timings, int voltage, int frequency)
    {
        if (voltage < 0) throw new NegativeArgumentException(nameof(voltage));
        if (frequency < 0) throw new NegativeArgumentException(nameof(frequency));

        Timings = timings;
        Voltage = voltage;
        Frequency = frequency;
    }

    public Timings Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}