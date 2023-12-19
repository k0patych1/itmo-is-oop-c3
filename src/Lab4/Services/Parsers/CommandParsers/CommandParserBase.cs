using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers;

public abstract class CommandParserBase
{
    private readonly FlagParserBase? _flagParser;

    private CommandParserBase? _nextCommandParser;

    protected CommandParserBase(FlagParserBase? flagParser)
    {
        _flagParser = flagParser;
    }

    protected abstract IReadOnlyCollection<string> NameOfCommand { get; }

    protected abstract int NumOfRequiredArguments { get; }

    public CommandParserBase SetNextCommandParser(CommandParserBase nextCommandParser)
    {
        _nextCommandParser = nextCommandParser;

        return nextCommandParser;
    }

    public abstract CommandBase ParseCommand(string[] args);

    protected bool IsCanBeParsed(string[] args)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        int numOfWordsOfCommand = NameOfCommand.Count;

        int numOfWordsRequiredForCommand = numOfWordsOfCommand + NumOfRequiredArguments;
        int numOfArgs = args.Length;

        return numOfWordsRequiredForCommand <= numOfArgs &&
               NameOfCommand.SequenceEqual(args.Take(numOfWordsOfCommand));
    }

    protected CommandBase TryParseNextCommand(string[] args)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        if (_nextCommandParser is not null) return _nextCommandParser.ParseCommand(args);

        throw new CommandParseException("Can't parse : " + args[0]);
    }

    protected HashSet<FlagBase> ParseFlags(string[] args)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        var flags = new HashSet<FlagBase>();

        int numOfWordsOfCommand = NameOfCommand.Count;
        int currentParsingIndex = numOfWordsOfCommand + NumOfRequiredArguments;
        int numOfArgs = args.Length;

        while (currentParsingIndex < numOfArgs)
        {
            if (_flagParser is null)
                throw new InvalidParameterFlagException("Can't parse this flag : " + args[currentParsingIndex]);

            flags.Add(_flagParser.ParseFlag(args, ref currentParsingIndex));
        }

        return flags;
    }
}