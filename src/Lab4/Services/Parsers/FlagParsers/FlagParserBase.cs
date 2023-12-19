using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

public abstract class FlagParserBase
{
    private FlagParserBase? _nextFlagParser;

    protected abstract string ShortNameOfFlag { get; }

    protected abstract string FullNameOfFlag { get; }

    public FlagParserBase SetNextFlagParser(FlagParserBase nextFlagParser)
    {
        _nextFlagParser = nextFlagParser;

        return nextFlagParser;
    }

    public abstract FlagBase ParseFlag(string[] args, ref int startIndex);

    protected bool IsCanBeParsed(string[] args, int startIndex)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        return startIndex + 1 < args.Length &&
               (args[startIndex].Equals(FullNameOfFlag, StringComparison.Ordinal) ||
               args[startIndex].Equals(ShortNameOfFlag, StringComparison.Ordinal));
    }

    protected FlagBase TryParseNextFlag(string[] args, ref int startIndex)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        if (_nextFlagParser is not null) return _nextFlagParser.ParseFlag(args, ref startIndex);

        throw new CommandParseException("Can't parse : " + args[0]);
    }
}