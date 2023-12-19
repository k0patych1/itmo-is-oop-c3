using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.ConnectionCommandsParsers;

public class ConnectCommandParser : CommandParserBase
{
    public ConnectCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "connect" };

    protected override int NumOfRequiredArguments => 1;

    public override CommandBase ParseCommand(string[] args)
    {
        return IsCanBeParsed(args) ?
            new ConnectCommand(args[NameOfCommand.Count], ParseFlags(args)) :
            TryParseNextCommand(args);
    }
}