using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.ConnectionCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.ConnectionCommandsParsers;

public class DisconnectCommandParser : CommandParserBase
{
    public DisconnectCommandParser(FlagParserBase? flagParser)
        : base(flagParser)
    {
    }

    protected override IReadOnlyCollection<string> NameOfCommand => new[] { "disconnect" };

    protected override int NumOfRequiredArguments => 0;

    public override CommandBase ParseCommand(string[] args)
    {
        return IsCanBeParsed(args) ?
            new DisconnectCommand(ParseFlags(args)) :
            TryParseNextCommand(args);
    }
}