using System;
using Serilog;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Telegram;

public class Telegram : ITelegram
{
    private readonly ILogger _logger;

    public Telegram(ILogger logger)
    {
        _logger = logger;
    }

    public void SendMessage(string message, int sleepTime)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _logger.Information("[Telegram] " + message);
    }
}