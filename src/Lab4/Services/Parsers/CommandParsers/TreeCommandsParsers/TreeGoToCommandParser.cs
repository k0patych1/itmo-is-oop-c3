using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.TreeCommandsParsers;

public class TreeGoToCommandParser : CommandParserBase
{
    public TreeGoToCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "tree", "goto" };

    protected override int NumOfRequiredArguments => 1;

    public override CommandBase ParseCommand(string[] args)
    {
        return IsCanBeParsed(args)
            ? new TreeGoToCommand(args[NameOfCommand.Count], ParseFlags(args))
            : TryParseNextCommand(args);
    }
}