using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public abstract class CommandBase
{
    protected CommandBase(ICollection<FlagBase> flags)
    {
        Flags = flags;
    }

    protected ICollection<FlagBase> Flags { get; }

    public abstract void Execute(ref FileSystemBase? fileSystem);
}