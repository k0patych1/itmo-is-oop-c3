using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

public class SamplingDepthParser : FlagParserBase
{
    protected override string ShortNameOfFlag => "-d";

    protected override string FullNameOfFlag => "--depth";

    public override FlagBase ParseFlag(string[] args, ref int startIndex)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        if (!IsCanBeParsed(args, startIndex)) return TryParseNextFlag(args, ref startIndex);

        var fileOutputMode = new SamplingDepth(args[startIndex + 1]);

        startIndex += 2;

        return fileOutputMode;
    }
}