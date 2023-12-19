using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;

public class TreeGoToCommand : CommandBase
{
    private readonly string _path;

    public TreeGoToCommand(string path, ICollection<FlagBase> flags)
        : base(flags)
    {
        _path = path;
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is null)
            throw new CommandExecuteException("Attempting to execute a command without connecting to the file system");

        fileSystem.ChangeCurrentDirectory(_path);
    }
}