using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem.LocalFileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;

public class ConnectCommand : CommandBase
{
    private readonly string _path;

    public ConnectCommand(string path, ICollection<FlagBase> flags)
        : base(flags)
    {
        _path = path;
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is not null)
            throw new CommandExecuteException("You are already connected to the file system");

        FlagBase fileSystemFlag = Flags.FirstOrDefault(flag => flag is FileSystemMode)
                                  ?? throw new CommandExecuteException("Can't connect to undefined file system");

        fileSystem = fileSystemFlag.Value switch
        {
            "local" => new LocalFileSystem(_path),
            _ => throw new InvalidParameterFlagException("Can't parse this flag value : " + fileSystemFlag.Value),
        };
    }
}