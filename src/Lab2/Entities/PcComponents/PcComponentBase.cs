namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcComponents;

public abstract class PcComponentBase
{
    protected PcComponentBase(string name)
    {
        Name = name;
    }

    public string Name { get; }
}