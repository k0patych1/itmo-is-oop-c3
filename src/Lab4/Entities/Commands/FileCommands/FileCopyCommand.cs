using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;

public class FileCopyCommand : CommandBase
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath, ICollection<FlagBase> flags)
        : base(flags)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is null)
            throw new CommandExecuteException("Attempting to execute a command without connecting to the file system");

        fileSystem.CopyFile(_sourcePath, _destinationPath);
    }
}