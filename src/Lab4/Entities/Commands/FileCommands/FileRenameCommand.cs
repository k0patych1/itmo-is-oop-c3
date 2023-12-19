using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;

public class FileRenameCommand : CommandBase
{
    private readonly string _path;

    private readonly string _newName;

    public FileRenameCommand(string newName, string path, ICollection<FlagBase> flags)
        : base(flags)
    {
        _newName = newName;
        _path = path;
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is null)
            throw new CommandExecuteException("Attempting to execute a command without connecting to the file system");

        fileSystem.RenameFile(_path, _newName);
    }
}