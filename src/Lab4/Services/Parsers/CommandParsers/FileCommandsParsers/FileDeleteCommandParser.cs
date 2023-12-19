using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.FileCommandsParsers;

public class FileDeleteCommandParser : CommandParserBase
{
    public FileDeleteCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "file", "delete" };

    protected override int NumOfRequiredArguments => 1;

    public override CommandBase ParseCommand(string[] args)
    {
        return IsCanBeParsed(args) ?
            new FileDeleteCommand(args[NameOfCommand.Count], ParseFlags(args)) :
            TryParseNextCommand(args);
    }
}