using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Telegram;

public class TelegramAdapter : IMessenger
{
    private readonly Telegram _telegram;
    private readonly int _sleepTime;

    public TelegramAdapter(Telegram telegram, int sleepTime)
    {
        _telegram = telegram;
        _sleepTime = sleepTime;
    }

    public void SendMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _telegram.SendMessage(message.Body, _sleepTime);
    }
}