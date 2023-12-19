using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.FileCommandsParsers;

public class FileCopyCommandParser : CommandParserBase
{
    public FileCopyCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "file", "copy" };

    protected override int NumOfRequiredArguments => 2;

    public override CommandBase ParseCommand(string[] args)
    {
        if (!IsCanBeParsed(args)) return TryParseNextCommand(args);

        return new FileCopyCommand(
            args[NameOfCommand.Count],
            args[NameOfCommand.Count + 1],
            ParseFlags(args));
    }
}