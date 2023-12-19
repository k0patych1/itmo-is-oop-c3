using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.ConnectionCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.FileCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.CommandParsers.TreeCommandsParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Services.Parsers.FlagParsers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args is null) throw new ArgumentNullException(nameof(args));

        var parser1 = new FileShowCommandParser(new FileOutputModeParser());
        var parser2 = new ConnectCommandParser(new FileSystemModeParser());
        var parser3 = new TreeListCommandParser(new SamplingDepthParser());
        var parser4 = new DisconnectCommandParser(null);
        var parser5 = new TreeGoToCommandParser(null);
        var parser6 = new FileCopyCommandParser(null);
        var parser7 = new FileDeleteCommandParser(null);
        var parser8 = new FileRenameCommandParser(null);
        var parser9 = new FileMoveCommandParser(null);

        parser1.SetNextCommandParser(parser2);
        parser2.SetNextCommandParser(parser3);
        parser3.SetNextCommandParser(parser4);
        parser4.SetNextCommandParser(parser5);
        parser5.SetNextCommandParser(parser6);
        parser6.SetNextCommandParser(parser7);
        parser7.SetNextCommandParser(parser8);
        parser8.SetNextCommandParser(parser9);

        if (args.Length != 0) parser1.ParseCommand(args);

        FileSystemBase? fileSystem = null;

        while (true)
        {
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) break;

            args = input.Split(" ");

            CommandBase command = parser1.ParseCommand(args);

            command.Execute(ref fileSystem);
        }
    }
}