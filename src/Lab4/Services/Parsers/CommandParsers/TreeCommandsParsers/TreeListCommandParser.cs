using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.TreeCommandsParsers;

public class TreeListCommandParser : CommandParserBase
{
    public TreeListCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "tree", "list" };

    protected override int NumOfRequiredArguments => 0;

    public override CommandBase ParseCommand(string[] args)
    {
        return IsCanBeParsed(args) ?
            new TreeListCommand(ParseFlags(args)) :
            TryParseNextCommand(args);
    }
}