using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Services.OutputFileSystemManagers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;

public class TreeListCommand : CommandBase
{
    public TreeListCommand(ICollection<FlagBase> flags)
        : base(flags)
    {
    }

    public override void Execute(ref FileSystemBase? fileSystem)
    {
        if (fileSystem is null)
            throw new CommandExecuteException("Attempting to execute a command without connecting to the file system");

        FlagBase? outputFlag = Flags.FirstOrDefault(flag => flag is FileOutputMode);

        fileSystem.OutputFileSystemManager = new ConsoleFileSystemManager();

        if (outputFlag is not null)
        {
            fileSystem.OutputFileSystemManager = outputFlag.Value switch
            {
                "console" => new ConsoleFileSystemManager(),
                _ => throw new InvalidParameterFlagException("Can't parse this flag value : " + outputFlag.Value),
            };
        }

        FlagBase? samplingDepth = Flags.FirstOrDefault(flag => flag is SamplingDepth);

        if (samplingDepth is null)
        {
            fileSystem.ShowTree();
        }
        else
        {
            fileSystem.ShowTree(int.Parse(samplingDepth.Value, CultureInfo.InvariantCulture));
        }
    }
}