using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;

public class DisconnectCommand : CommandBase
{
    public DisconnectCommand(ICollection<FlagBase> flags)
        : base(flags)
    {
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is null)
            throw new CommandExecuteException("Unable to disconnect from an unmounted file system");
        fileSystem = null;
    }
}