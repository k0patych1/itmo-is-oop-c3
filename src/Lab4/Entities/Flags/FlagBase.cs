namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

public abstract class FlagBase
{
    protected FlagBase(string value)
    {
        Value = value;
    }

    public string Value { get; }
}