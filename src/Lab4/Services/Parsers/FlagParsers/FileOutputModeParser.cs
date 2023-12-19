using Itmo.ObjectOrientedProgramming.Lab4.Entities.Flags;

namespace Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

public class FileOutputModeParser : FlagParserBase
{
    protected override string ShortNameOfFlag => "-m";

    protected override string FullNameOfFlag => "--mode";

    public override FlagBase ParseFlag(string[] args, ref int startIndex)
    {
        if (!IsCanBeParsed(args, startIndex)) return TryParseNextFlag(args, ref startIndex);

        var fileOutputMode = new FileOutputMode(args[startIndex + 1]);

        startIndex += 2;

        return fileOutputMode;
    }
}